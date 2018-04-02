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
    /// Represents the Grupo collection view model.
    /// </summary>
    public partial class GrupoCollectionViewModel : CollectionViewModel<Grupo, int, IPlanningOtherUnitOfWork> {

        /// <summary>
        /// Creates a new instance of GrupoCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static GrupoCollectionViewModel Create(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new GrupoCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the GrupoCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the GrupoCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected GrupoCollectionViewModel(IUnitOfWorkFactory<IPlanningOtherUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Grupo) {
        }
    }
}