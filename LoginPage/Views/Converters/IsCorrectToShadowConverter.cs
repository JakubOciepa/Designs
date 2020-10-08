using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Effects;


namespace LoginPage.Views.Converters
{
    class IsCorrectToShadowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var shadow = new DropShadowEffect();

            if (!(bool)value)
            {
                shadow.Opacity = 0.2;
                shadow.Color = Color.FromRgb(0xdd, 0x74, 0x23);
                shadow.Direction = 300;

                return shadow;
            }

            shadow.Opacity = 0.2;
            shadow.Color = Color.FromRgb(0, 0xA8, 0xC6);
            shadow.Direction = 300;

            return shadow;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}