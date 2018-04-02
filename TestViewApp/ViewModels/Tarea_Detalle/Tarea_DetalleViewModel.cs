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
    /// Represents the single Tarea_Detalle object view model.
    /// </summary>
    public partial class Tarea_DetalleViewModel : SingleObjectViewModel<Tarea_Detalle, int, IPlanningOtherUnitOfWork> {

        /// <summary>
        /// Creates a new instance of Tarea_DetalleViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static Tarea_DetalleViewModel Create(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new Tarea_DetalleViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the Tarea_DetalleViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the Tarea_DetalleViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected Tarea_DetalleViewModel(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Tarea_Detalle, x => x.Estado) {
                }


        protected override void RefreshLookUpCollections(bool raisePropertyChanged) {
            base.RefreshLookUpCollections(raisePropertyChanged);
                UsuarioDetailEntities = CreateAddRemoveDetailEntitiesViewModel(x => x.Usuario, x => x.Usuario);
        }
        /// <summary>
        /// The view model that contains a look-up collection of Tarea for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Tarea> LookUpTarea {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (Tarea_DetalleViewModel x) => x.LookUpTarea,
                    getRepositoryFunc: x => x.Tarea);
            }
        }

    public virtual AddRemoveDetailEntitiesViewModel<Tarea_Detalle, Int32, Usuario, Int32, IPlanningOtherUnitOfWork> UsuarioDetailEntities { get; protected set; }
    }
}
