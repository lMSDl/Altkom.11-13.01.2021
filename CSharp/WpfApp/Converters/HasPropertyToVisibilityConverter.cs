using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfApp.Converters
{
    public class HasPropertyToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public string PropertyName { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.GetType().GetProperty(PropertyName) != null ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
