using Infragistics.Documents.Excel;
using Infragistics.Documents.Excel.PredefinedShapes;
using System;
using System.Collections.Generic;
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

namespace ObjectOnXamSpreadSheet
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Workbook wb = new Workbook(WorkbookFormat.Excel2007);

            Worksheet ws = wb.Worksheets.Add("sheet1");

            //レクタングルオブジェクトを作成
            RectangleShape shape = (RectangleShape)WorksheetShape.CreatePredefinedShape(PredefinedShapeType.Rectangle);
            shape.TopLeftCornerCell = ws.Rows[2].Cells[2];
            shape.TopLeftCornerPosition = new Point(50, 100);
            shape.BottomRightCornerCell = ws.Rows[10].Cells[10];
            shape.BottomRightCornerPosition = new Point(50, 100);

            shape.Fill = ShapeFill.FromColor(System.Windows.Media.Colors.SteelBlue);
            shape.Text = new Infragistics.Documents.Excel.FormattedText("Lorem ipsum dolor sit amet, consectetur adipisci elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");

            ws.Shapes.Add(shape);

            xamSpreadSheet1.Workbook = wb;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            xamSpreadSheet1.Workbook.Save(@"..\..\Excel\Book.xlsx");
        }
    }
}
