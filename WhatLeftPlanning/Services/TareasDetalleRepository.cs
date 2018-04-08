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

            var detalles = dbSet
                .Where(x => x.Estado.Equals("S") &&
                            x.Tarea.Estado.Equals("A")).ToList();

            var xList = detalles.Select(x => x.Usuarios).First().ToList();
            var existeUsuario = xList.Contains(DatosEstaticos.CurrentUser);

            var TareaDetalle = detalles.Where(x => x.Usuarios.ToList().Contains(DatosEstaticos.CurrentUser)).ToList();

                //DatosEstaticos.CurrentUser.Tarea
                //.Where(x => x.Estado.Equals("S")
                //        && x.Tarea.Estado.Equals("A"))
                //.ToList();

            return TareaDetalle;
        }

    }
}
