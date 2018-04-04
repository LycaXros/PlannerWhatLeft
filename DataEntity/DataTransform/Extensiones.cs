using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity.DataTransform
{
    public static class Extensiones
    {
        public static List<string> ObtenerRoles(this Model.Usuario usuario)
        {
            List<string> res = new List<string>();
            foreach (var item in usuario.Roles)
            {
                res.Add(item.Nombre);
            }
            return res;
        }
    }

}
