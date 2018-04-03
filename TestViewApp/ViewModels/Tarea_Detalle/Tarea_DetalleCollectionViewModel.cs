using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using TestViewApp.PlanningOtherDataModel;
using TestViewApp.Common;
using DataEntity.Model;

namespace TestViewApp.ViewModels {

    /// <summary>
    /// Represents the Tarea_Detalle collection view model.
    /// </summary>
    public partial class Tarea_DetalleCollectionViewModel : CollectionViewModel<Tarea_Detalle, int, IPlanningOtherUnitOfWork> {

        /// <summary>
        /// Creates a new instance of Tarea_DetalleCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static Tarea_DetalleCollectionViewModel Create(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new Tarea_DetalleCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the Tarea_DetalleCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the Tarea_DetalleCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected Tarea_DetalleCollectionViewModel(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Tarea_Detalle) {
        }
    }
}