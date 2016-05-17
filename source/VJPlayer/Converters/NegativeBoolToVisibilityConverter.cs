using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace VJPlayer.Converters
{
    public class NegativeBoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibleValue = value as bool?;
            if (visibleValue == null || visibleValue == true)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibleValue = value as Visibility?;
            if (visibleValue == null || visibleValue == Visibility.Visible)
                return false;

            return true;
        }
    }
}
