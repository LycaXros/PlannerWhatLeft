using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WhatLeftPlanning.Converters
{
    public class TareaEstadoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return getSortedEstatus(value == null ?"": value.ToString());

        }

        private string getSortedEstatus(string v)
        {
            switch (v)
            {
                case "A":
                    return "Activa";
                case "D":
                    return "Elminida";
                case "I":
                    return "Incompleta";
                default:
                    return "Estado no Valido";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
