using Sample.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Sample.Converter
{
    public class StrokeConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            NodeType nodeType = (NodeType)value;
            //switch (nodeType)
            //{
            //    case NodeType.CUSTOMER:
            //        return new SolidColorBrush(Colors.Green);
            //    case NodeType.SALES:
            //        return new SolidColorBrush(Colors.Blue);
            //    case NodeType.MANAGEMENT:
            //        return new SolidColorBrush(Colors.Red);
            //    case NodeType.CREDIT_DEPARTMENT:
            //        return new SolidColorBrush(Colors.Orange);
            //}
            return new SolidColorBrush(Colors.LightGray);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
