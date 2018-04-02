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
    /// Represents the Rol collection view model.
    /// </summary>
    public partial class RolCollectionViewModel : ReadOnlyCollectionViewModel<Rol, IPlanningOtherUnitOfWork> {

        /// <summary>
        /// Creates a new instance of RolCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static RolCollectionViewModel Create(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new RolCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the RolCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the RolCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected RolCollectionViewModel(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Rol) {
        }
    }
}