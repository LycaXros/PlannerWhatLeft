using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TestViewApp.Converter
{
    [ValueConversion(typeof(string), typeof(string))]
    public class StringTransformConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? null : DataEntity.DataTransform.Encriptador.Desencriptar(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? null : DataEntity.DataTransform.Encriptador.Encriptar(value.ToString());
        }
    }
}
