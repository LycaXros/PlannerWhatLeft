using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using TestViewApp.PlanningOtherDataModel;
using TestViewApp.Common;
using DataEntity.Model;

namespace TestViewApp.ViewModels {

    /// <summary>
    /// Represents the single Grupo object view model.
    /// </summary>
    public partial class GrupoViewModel : SingleObjectViewModel<Grupo, int, IPlanningOtherUnitOfWork> {

        /// <summary>
        /// Creates a new instance of GrupoViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static GrupoViewModel Create(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new GrupoViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the GrupoViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the GrupoViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected GrupoViewModel(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Grupo, x => x.Descripcion) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of UsuarioGrupo for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<UsuarioGrupo> LookUpUsuarioGrupo {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (GrupoViewModel x) => x.LookUpUsuarioGrupo,
                    getRepositoryFunc: x => x.UsuarioGrupo);
            }
        }


        /// <summary>
        /// The view model for the GrupoUsuariosRef detail collection.
        /// </summary>
        public ReadOnlyCollectionViewModelBase<UsuarioGrupo, UsuarioGrupo, IPlanningOtherUnitOfWork> GrupoUsuariosRefDetails {
            get { return GetReadOnlyDetailsCollectionViewModel((GrupoViewModel x) => x.GrupoUsuariosRefDetails, x => x.UsuarioGrupo, x => x.GrupoID); }
        }
    }
}
