using DataEntity.Model;
using DevExpress.Mvvm.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestViewApp.PlanningOtherDataModel {

    /// <summary>
    /// IPlanningOtherUnitOfWork extends the IUnitOfWork interface with repositories representing specific entities.
    /// </summary>
    public interface IPlanningOtherUnitOfWork : IUnitOfWork {
        
        /// <summary>
        /// The Grupo entities repository.
        /// </summary>
		IRepository<Grupo, int> Grupo { get; }
        
        /// <summary>
        /// The Rol entities repository.
        /// </summary>
		IRepository<Rol, int> Rol { get; }
        
        /// <summary>
        /// The Tarea entities repository.
        /// </summary>
		IRepository<Tarea, int> Tarea { get; }
        
        /// <summary>
        /// The Tarea_Detalle entities repository.
        /// </summary>
		IRepository<Tarea_Detalle, int> Tarea_Detalle { get; }
        
        /// <summary>
        /// The Tipo_Tarea entities repository.
        /// </summary>
		IRepository<Tipo_Tarea, int> Tipo_Tarea { get; }
        
        /// <summary>
        /// The Usuario entities repository.
        /// </summary>
		IRepository<Usuario, int> Usuario { get; }
        
        /// <summary>
        /// The UsuarioGrupo entities repository.
        /// </summary>
		IRepository<UsuarioGrupo, Tuple<int, int>> UsuarioGrupo { get; }
    }
}
