using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace BooksSample.Utilities
{
    public class StringArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string[] names = (string[])value;
            return string.Join(parameter?.ToString() ?? ", ", names);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language) =>
            value.ToString().Split(',');
    }
}
