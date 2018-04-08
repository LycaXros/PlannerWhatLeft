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
    /// Represents the single Usuario object view model.
    /// </summary>
    public partial class UsuarioViewModel : SingleObjectViewModel<Usuario, int, IPlanningOtherUnitOfWork> {

        /// <summary>
        /// Creates a new instance of UsuarioViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static UsuarioViewModel Create(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new UsuarioViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the UsuarioViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the UsuarioViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected UsuarioViewModel(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Usuario, x => x.Nombre) {
                }


        protected override void RefreshLookUpCollections(bool raisePropertyChanged) {
            base.RefreshLookUpCollections(raisePropertyChanged);
                Tarea_DetalleDetailEntities = CreateAddRemoveDetailEntitiesViewModel(x => x.Tarea_Detalle, x => x.DetalleTareas);
                RolesDetailEntities = CreateAddRemoveDetailEntitiesViewModel(x => x.Rol, x => x.Roles);
        }
        /// <summary>
        /// The view model that contains a look-up collection of UsuarioGrupo for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<UsuarioGrupo> LookUpUsuarioGrupo {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (UsuarioViewModel x) => x.LookUpUsuarioGrupo,
                    getRepositoryFunc: x => x.UsuarioGrupo);
            }
        }

    public virtual AddRemoveDetailEntitiesViewModel<Usuario, Int32, Tarea_Detalle, Int32, IPlanningOtherUnitOfWork> Tarea_DetalleDetailEntities { get; protected set; }
    public virtual AddRemoveDetailEntitiesViewModel<Usuario, Int32, Rol, Int32, IPlanningOtherUnitOfWork> RolesDetailEntities { get; protected set; }

        /// <summary>
        /// The view model for the UsuarioGruposRef detail collection.
        /// </summary>
        public ReadOnlyCollectionViewModelBase<UsuarioGrupo, UsuarioGrupo, IPlanningOtherUnitOfWork> UsuarioGruposRefDetails {
            get { return GetReadOnlyDetailsCollectionViewModel((UsuarioViewModel x) => x.UsuarioGruposRefDetails, x => x.UsuarioGrupo, x => x.UsuarioID); }
        }
    }
}
