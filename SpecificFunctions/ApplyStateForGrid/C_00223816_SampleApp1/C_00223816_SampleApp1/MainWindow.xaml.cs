using Infragistics.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace C_00223816_SampleApp1
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


        // このbutton1_Clickは例外が発生します。再現確認用です。
        // Persistence Frameworkの制限事項に該当します。
        // https://jp.infragistics.com/help/wpf/persistence-about-ig-control-persistence-framework
        // 「Persistence Framework では、（中略）クロスプラットフォームコントロールではないコントロールは完全にはサポートされません。
        // ※XamDataGridは、クロスプラットフォームコントロールではありません。
        // 似たような会話がForumにありました。
        // https://www.infragistics.com/community/forums/f/ultimate-ui-for-wpf/78308/stackoverflowexception-with-persistencemanager-using-xamdatagrid
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // Saves all sourceDataGrid properties 
            // except Rows, ActiveCell, SelectedCells, SelectedRows (ignored by default)
            MemoryStream memoryStream = PersistenceManager.Save(sourceDataGrid);

            memoryStream.Position = 0;

            // Loads all saved properties from sourceDataGrid to targetDataGrid
            PersistenceManager.Load(targetDataGrid, memoryStream);
        }

        // 代わりのコードです。
        // SaveCustomizations
        // https://jp.infragistics.com/help/wpf/xamdatapresenter-save-field-customizations
        // LoadCustomizations
        // https://jp.infragistics.com/help/wpf/xamdatapresenter-load-field-customizations
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                sourceDataGrid.SaveCustomizations(ms);
                ms.Position = 0;
                targetDataGrid.LoadCustomizations(ms);
            }
        }
    }
}
