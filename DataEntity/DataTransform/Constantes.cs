using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity.DataTransform
{
    public class Constantes
    {
        public const int TipoTareaTemporal = 2;
        public const int TipoTareaDiaria = 1;

    }
    public class RolConstantes
    {
        public const int Administrador = 1;
        public const int Lider = 2;
        public const int Normal = 3;
    }
    public class TareaEstados
    {
        public const string Activa = "A";
        public const string Eliminida = "D";
        public const string Incompleta = "I";
    }

    public class TareaDetalleEstados
    {
        public const string Completa = "C";
        public const string Incompleta = "S";
    }
}
