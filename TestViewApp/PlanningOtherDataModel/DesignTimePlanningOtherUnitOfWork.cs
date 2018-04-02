using DataEntity.Model;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.DesignTime;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestViewApp.PlanningOtherDataModel {

    /// <summary>
    /// A PlanningOtherDesignTimeUnitOfWork instance that represents the design-time implementation of the IPlanningOtherUnitOfWork interface.
    /// </summary>
    public class PlanningOtherDesignTimeUnitOfWork : DesignTimeUnitOfWork, IPlanningOtherUnitOfWork {

        /// <summary>
        /// Initializes a new instance of the PlanningOtherDesignTimeUnitOfWork class.
        /// </summary>
        public PlanningOtherDesignTimeUnitOfWork() {
        }

        IRepository<Grupo, int> IPlanningOtherUnitOfWork.Grupo {
            get { return GetRepository((Grupo x) => x.ID); }
        }

        IRepository<Rol, int> IPlanningOtherUnitOfWork.Rol {
            get { return GetRepository((Rol x) => x.ID); }
        }

        IRepository<Tarea, int> IPlanningOtherUnitOfWork.Tarea {
            get { return GetRepository((Tarea x) => x.ID); }
        }

        IRepository<Tarea_Detalle, int> IPlanningOtherUnitOfWork.Tarea_Detalle {
            get { return GetRepository((Tarea_Detalle x) => x.ID); }
        }

        IRepository<Tipo_Tarea, int> IPlanningOtherUnitOfWork.Tipo_Tarea {
            get { return GetRepository((Tipo_Tarea x) => x.ID); }
        }

        IRepository<Usuario, int> IPlanningOtherUnitOfWork.Usuario {
            get { return GetRepository((Usuario x) => x.ID); }
        }

        IRepository<UsuarioGrupo, Tuple<int, int>> IPlanningOtherUnitOfWork.UsuarioGrupo {
            get { return GetRepository((UsuarioGrupo x) => Tuple.Create(x.GrupoID, x.UsuarioID)); }
        }
    }
}
