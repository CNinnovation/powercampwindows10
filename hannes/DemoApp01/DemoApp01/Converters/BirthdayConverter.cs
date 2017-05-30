using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace DemoApp01.Converters
{
    public class BirthdayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ( value is DateTime birthDay )
            {
                if (!birthDay.Equals(DateTime.MinValue))
                {
                    return string.Format("{0:dd.MM.yyyy}", birthDay);
                }
            }

            return "-";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
