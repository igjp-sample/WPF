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
using Sample.Models;
//using Line = Sample.Models.Line;
//using Node = Sample.Models.Node;


namespace Sample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.xamDiagram.RefreshLayout();

            new DiagramNode().Stroke = new SolidColorBrush(Colors.Red);
        }

        private void xamDiagram_ItemAdding(object sender, Infragistics.Controls.Charts.DiagramItemAddingEventArgs e)
        {
            XamDiagram digram = sender as XamDiagram;
            DiagramConnection connection = e.Item as DiagramConnection;
            DiagramNode node = e.Item as DiagramNode;



            if (node != null && node.Geometry != null)
            {
                ObservableCollection<Node> nodes = digram.ItemsSource as ObservableCollection<Node>;
                Node addTask = new Node();
                xamDiagram.Items.CollectionChanged += Items_CollectionChanged;
                nodes.Add(addTask);
                e.Cancel = true;
            }
            if (connection != null)
            {
                ObservableCollection<Models.Line> lines = digram.ConnectionsSource as ObservableCollection<Models.Line>;
                Models.Line addRelation = new Models.Line();
                xamDiagram.Items.CollectionChanged += Items_CollectionChanged;
                lines.Add(addRelation);
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

                    this.xamDiagram.RefreshLayout();
                }
                DiagramConnection connection = e.NewItems[0] as DiagramConnection;
                if (connection != null)
                {
                    connection.StartPosition = wpOnDiagram;
                    connection.EndPosition = wpOnDiagram;
                    connection.Visibility = Visibility.Hidden;

                    connection.Dispatcher.Invoke(
                    new Action(() => {
                        connection.StartPosition = new System.Windows.Point(connection.StartPosition.X - 18, connection.StartPosition.Y - 18);
                        connection.EndPosition = new System.Windows.Point(connection.EndPosition.X + 18, connection.EndPosition.Y + 18);
                        connection.Visibility = Visibility.Visible;
                    }), DispatcherPriority.Background
                    );

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.xamDiagram.RefreshLayout();
        }

        private void xamDiagram_SelectionChanged(object sender, DiagramSelectionChangedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var nodeItem in xamDiagram.SelectedItems)
            {
                DiagramConnection connection = nodeItem as DiagramConnection;
                DiagramNode node = nodeItem as DiagramNode;

                if(connection != null)
                {
                    sb.AppendLine("StartPosition:" + connection.StartPosition.ToString());
                    sb.AppendLine("EndPosition:" + connection.EndPosition.ToString());
                }
                else if (node != null)
                {
                    sb.AppendLine("Position:" + node.Position.ToString());
                }

            }
            txtLog.Text = sb.ToString();
        }

        private void xamDiagram_NodeMoved(object sender, DiagramNodeMovedEventArgs e)
        {
            this.xamDiagram.RefreshLayout();


        }
    }
}
