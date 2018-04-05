using DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatLeftPlanning.Startup;

namespace WhatLeftPlanning.Services
{
    public class TareasDetalleRepository : Repositorio<Tarea_Detalle>, ITareasDetalleRepository
    {
        public TareasDetalleRepository(PlanningOther context)
            : base(context)
        {

        }
        public async Task<IEnumerable<Tarea_Detalle>> ObtenerTareasUsuarioActual()
        {
            await Task.Factory.StartNew
                (() => System.Threading.Thread.Sleep(50));

            var TareaDetalle =
                DatosEstaticos.CurrentUser.Tarea
                .Where(x => x.Estado.Equals("S")
                        && x.Tarea.Estado.Equals("A"))
                .ToList();

            return TareaDetalle;
        }

    }
}
