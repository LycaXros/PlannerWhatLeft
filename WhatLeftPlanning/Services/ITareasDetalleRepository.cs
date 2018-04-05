using System.Collections.Generic;
using System.Threading.Tasks;
using DataEntity.Model;

namespace WhatLeftPlanning.Services
{
    public interface ITareasDetalleRepository : IRepositorio<Tarea_Detalle>
    {
        Task<IEnumerable<Tarea_Detalle>> ObtenerTareasUsuarioActual();
    }
}