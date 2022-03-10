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
    public class FillConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            NodeType nodeType = (NodeType)value;
            switch (nodeType)
            {
                case NodeType.CUSTOMER:
                    return new SolidColorBrush(Color.FromRgb(128,189,62));
                case NodeType.SALES:
                    return new SolidColorBrush(Color.FromRgb(47, 169, 223));
                case NodeType.MANAGEMENT:
                    return new SolidColorBrush(Color.FromRgb(237, 87, 36));
                case NodeType.CREDIT_DEPARTMENT:
                    return new SolidColorBrush(Color.FromRgb(254, 183, 25));
            }
            return new SolidColorBrush(Colors.Red);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
