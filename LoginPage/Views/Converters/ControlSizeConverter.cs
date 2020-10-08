using System;
using System.Globalization;
using System.Windows.Data;

namespace LoginPage.Views.Converters
{
    public class ControlSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isDouble = double.TryParse((string)parameter, NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out var result);

            if (value is double size && isDouble)
            {
                if (size > 1000)
                    return size * result;
                return size * result;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
