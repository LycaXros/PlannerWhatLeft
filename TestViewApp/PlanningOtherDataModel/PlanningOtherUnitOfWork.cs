using DataEntity.Model;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.EF6;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestViewApp.PlanningOtherDataModel {

    /// <summary>
    /// A PlanningOtherUnitOfWork instance that represents the run-time implementation of the IPlanningOtherUnitOfWork interface.
    /// </summary>
    public class PlanningOtherUnitOfWork : DbUnitOfWork<PlanningOther>, IPlanningOtherUnitOfWork {

        public PlanningOtherUnitOfWork(Func<PlanningOther> contextFactory)
            : base(contextFactory) {
        }

        IRepository<Grupo, int> IPlanningOtherUnitOfWork.Grupo {
            get { return GetRepository(x => x.Set<Grupo>(), (Grupo x) => x.ID); }
        }

        IRepository<Rol, int> IPlanningOtherUnitOfWork.Rol {
            get { return GetRepository(x => x.Set<Rol>(), (Rol x) => x.ID); }
        }

        IRepository<Tarea, int> IPlanningOtherUnitOfWork.Tarea {
            get { return GetRepository(x => x.Set<Tarea>(), (Tarea x) => x.ID); }
        }

        IRepository<Tarea_Detalle, int> IPlanningOtherUnitOfWork.Tarea_Detalle {
            get { return GetRepository(x => x.Set<Tarea_Detalle>(), (Tarea_Detalle x) => x.ID); }
        }

        IRepository<Tipo_Tarea, int> IPlanningOtherUnitOfWork.Tipo_Tarea {
            get { return GetRepository(x => x.Set<Tipo_Tarea>(), (Tipo_Tarea x) => x.ID); }
        }

        IRepository<Usuario, int> IPlanningOtherUnitOfWork.Usuario {
            get { return GetRepository(x => x.Set<Usuario>(), (Usuario x) => x.ID); }
        }

        IRepository<UsuarioGrupo, Tuple<int, int>> IPlanningOtherUnitOfWork.UsuarioGrupo {
            get { return GetRepository(x => x.Set<UsuarioGrupo>(), (UsuarioGrupo x) => Tuple.Create(x.GrupoID, x.UsuarioID)); }
        }
    }
}
