using System;
using System.Globalization;
using Xamarin.Forms;

namespace dashy.Converters
{
    public class BooleanToColorConverter : IValueConverter
    {
        public Color False { get; set; }
        public Color True { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? True : False;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
