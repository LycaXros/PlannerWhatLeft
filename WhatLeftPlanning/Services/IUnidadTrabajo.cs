using DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatLeftPlanning.Services
{
    public interface IUnidadTrabajo : IDisposable
    {
        IUserRepository Usuarios { get; }
        ITareasDetalleRepository TareasDetalle { get; }
        ITareaRepository Tareas { get; }
        IGrupoRepository Grupos { get; }
        PlanningOther GetContext();
        /// <summary>
        /// Salvar <see cref="System.Data.Entity.DbContext"/>
        /// </summary>
        /// <returns></returns>
        Task<int> Complete();
    }
}
