using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using VJPlayer.Models;

namespace VJPlayer.Converters
{
    public class MediaModelPlayingStateToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibleValue = value as MediaModelState?;
            if (visibleValue == null) throw new ArgumentNullException(nameof(visibleValue));

            if(visibleValue == MediaModelState.Playing)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
