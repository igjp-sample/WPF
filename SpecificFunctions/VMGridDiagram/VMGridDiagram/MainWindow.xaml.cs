using Infragistics.Controls.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Task = VMGridDiagram.Models.Task;

namespace VMGridDiagram
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void XamDiagram_ItemAdding(object sender, Infragistics.Controls.Charts.DiagramItemAddingEventArgs e)
        {
            XamDiagram digram = sender as XamDiagram;
            DiagramConnection connection = e.Item as DiagramConnection;
            DiagramNode node = e.Item as DiagramNode;

            if (node != null)
            {
                ObservableCollection<Task> tasks = digram.ItemsSource as ObservableCollection<Task>;
                Task addTask = new Task();
                xamDiagram.Items.CollectionChanged += Items_CollectionChanged;
                tasks.Add(addTask);
                e.Cancel = true;
            }

        }

        private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            xamDiagram.Items.CollectionChanged -= Items_CollectionChanged;


            // 座標を特定
            System.Drawing.Point dp = System.Windows.Forms.Cursor.Position;
            System.Windows.Point wp = new System.Windows.Point(dp.X, dp.Y);
            System.Windows.Point wpOnDiagram = xamDiagram.PointFromScreen(wp);

            // 追加されたNode に対して処理を行う。
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                DiagramNode node = e.NewItems[0] as DiagramNode;
                if (node != null)
                {
                    // Node のサイズを調整した中央点を設定する。
                    node.Position = wpOnDiagram;
                    node.Visibility = Visibility.Hidden;

                    node.Dispatcher.Invoke(
                        new Action(() => {
                            var height = node.ActualHeight;
                            var width = node.ActualWidth;
                            node.Position = new System.Windows.Point(node.Position.X - (width / 2), node.Position.Y - (height / 2));
                            node.Visibility = Visibility.Visible;
                        }), DispatcherPriority.Background
                    );
                }
            }
        }

    }
}
