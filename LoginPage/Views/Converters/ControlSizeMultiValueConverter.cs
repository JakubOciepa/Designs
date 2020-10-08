using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace LoginPage.Views.Converters
{
    public class ControlSizeMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var casted = values.OfType<double>().ToList();

            if (casted.Count() == 2)
            {
                return casted[0] * casted[1];
            }


            return (double)values[0];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
