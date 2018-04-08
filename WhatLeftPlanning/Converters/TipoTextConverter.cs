using DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WhatLeftPlanning.Converters
{
    public class TipoTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            int val = 0;
            if (!int.TryParse(value.ToString(), out val)) return null;

            return GetValue(val);

        }

        private string GetValue(int val)
        {
            using (var ent = new PlanningOther())
            {
                var tipos = ent.Tipo_Tarea.ToList();

                return tipos.First(x => x.ID.Equals(val)).Nombre.ToString() ?? null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
