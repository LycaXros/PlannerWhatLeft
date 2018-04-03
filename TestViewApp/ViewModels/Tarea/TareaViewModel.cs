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
    /// Represents the single Tarea object view model.
    /// </summary>
    public partial class TareaViewModel : SingleObjectViewModel<Tarea, int, IPlanningOtherUnitOfWork> {

        /// <summary>
        /// Creates a new instance of TareaViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static TareaViewModel Create(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new TareaViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the TareaViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the TareaViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected TareaViewModel(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Tarea, x => x.Descripción) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of Tipo_Tarea for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Tipo_Tarea> LookUpTipo_Tarea {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (TareaViewModel x) => x.LookUpTipo_Tarea,
                    getRepositoryFunc: x => x.Tipo_Tarea);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of Tarea_Detalle for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Tarea_Detalle> LookUpTarea_Detalle {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (TareaViewModel x) => x.LookUpTarea_Detalle,
                    getRepositoryFunc: x => x.Tarea_Detalle);
            }
        }


        /// <summary>
        /// The view model for the TareaDetalles detail collection.
        /// </summary>
        public CollectionViewModelBase<Tarea_Detalle, Tarea_Detalle, int, IPlanningOtherUnitOfWork> TareaDetallesDetails {
            get {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (TareaViewModel x) => x.TareaDetallesDetails,
                    getRepositoryFunc: x => x.Tarea_Detalle,
                    foreignKeyExpression: x => x.TareaID,
                    navigationExpression: x => x.Tarea);
            }
        }
    }
}
