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
    /// Represents the Tipo_Tarea collection view model.
    /// </summary>
    public partial class Tipo_TareaCollectionViewModel : ReadOnlyCollectionViewModel<Tipo_Tarea, IPlanningOtherUnitOfWork> {

        /// <summary>
        /// Creates a new instance of Tipo_TareaCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static Tipo_TareaCollectionViewModel Create(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new Tipo_TareaCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the Tipo_TareaCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the Tipo_TareaCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected Tipo_TareaCollectionViewModel(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Tipo_Tarea) {
        }
    }
}