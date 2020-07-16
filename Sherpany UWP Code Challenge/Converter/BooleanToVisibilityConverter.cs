using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Sherpany_UWP_Code_Challange.Converter
{
    /// <summary>
    /// Passing a parameter of that is not null will invert the result.
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool val)
            {
                bool finalVal = parameter != null ? !val : val;
                return finalVal ? Visibility.Visible : Visibility.Collapsed;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}