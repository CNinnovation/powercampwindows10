using System;
using Windows.UI.Xaml.Data;

namespace BooksSample.Utilities
{
    public class StringArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language) =>
            string.Join(parameter?.ToString() ?? ", ", value as string[]);
        
        public object ConvertBack(object value, Type targetType, object parameter, string language) =>
            value.ToString().Split(',');
    }
}
