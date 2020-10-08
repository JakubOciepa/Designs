using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace LoginPage.Views.Converters
{
    public class SizeToDockConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((double)value < 600)
                return Dock.Top;

            return Dock.Left;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
