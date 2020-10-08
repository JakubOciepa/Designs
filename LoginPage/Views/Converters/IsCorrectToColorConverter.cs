using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace LoginPage.Views.Converters
{
    public class IsCorrectToColorConverter : IValueConverter, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var casted = values.OfType<bool>().ToList();

            if (casted.Count > 0 && casted[0])
                return Color.FromRgb(0xdd, 0x23, 0x2f);

            if(casted.Count > 0)
                casted.RemoveAt(0);

            if (casted.Count == 0)
                return Color.FromRgb(0, 0xA8, 0xC6);

            bool result = casted[0];

            casted.ForEach(x => result = result && x);

            if (!result)
                return Color.FromRgb(0xdd, 0x74, 0x23);

            return Color.FromRgb(0, 0xA8, 0xC6);

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (bool)value ? Color.FromArgb(0, 0, 0, 0) : Color.FromRgb(0xdd, 0x23, 0x2f);

            if (targetType == typeof(Brush))
                return new SolidColorBrush(color);

            return color;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
