using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using TestViewApp.Localization;using TestViewApp.PlanningOtherDataModel;

namespace TestViewApp.ViewModels {
    /// <summary>
    /// Represents the root POCO view model for the PlanningOther data model.
    /// </summary>
    public partial class PlanningOtherViewModel : DocumentsViewModel<PlanningOtherModuleDescription, IPlanningOtherUnitOfWork> {

		const string TablesGroup = "Tables";

		const string ViewsGroup = "Views";
	
        /// <summary>
        /// Creates a new instance of PlanningOtherViewModel as a POCO view model.
        /// </summary>
        public static PlanningOtherViewModel Create() {
            return ViewModelSource.Create(() => new PlanningOtherViewModel());
        }

		        static PlanningOtherViewModel() {
            MetadataLocator.Default = MetadataLocator.Create().AddMetadata<PlanningOtherMetadataProvider>();
        }
        /// <summary>
        /// Initializes a new instance of the PlanningOtherViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the PlanningOtherViewModel type without the POCO proxy factory.
        /// </summary>
        protected PlanningOtherViewModel()
		    : base(UnitOfWorkSource.GetUnitOfWorkFactory()) {
        }

        protected override PlanningOtherModuleDescription[] CreateModules() {
			return new PlanningOtherModuleDescription[] {
                new PlanningOtherModuleDescription(PlanningOtherResources.GrupoPlural, "GrupoCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Grupo)),
                new PlanningOtherModuleDescription(PlanningOtherResources.RolPlural, "RolCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Rol)),
                new PlanningOtherModuleDescription(PlanningOtherResources.TareaPlural, "TareaCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Tarea)),
                new PlanningOtherModuleDescription(PlanningOtherResources.Tarea_DetallePlural, "Tarea_DetalleCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Tarea_Detalle)),
                new PlanningOtherModuleDescription(PlanningOtherResources.Tipo_TareaPlural, "Tipo_TareaCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Tipo_Tarea)),
                new PlanningOtherModuleDescription(PlanningOtherResources.UsuarioPlural, "UsuarioCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Usuario)),
                new PlanningOtherModuleDescription(PlanningOtherResources.UsuarioGrupoPlural, "UsuarioGrupoCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.UsuarioGrupo)),
			};
        }
                	}

    public partial class PlanningOtherModuleDescription : ModuleDescription<PlanningOtherModuleDescription> {
        public PlanningOtherModuleDescription(string title, string documentType, string group, Func<PlanningOtherModuleDescription, object> peekCollectionViewModelFactory = null)
            : base(title, documentType, group, peekCollectionViewModelFactory) {
        }
    }
}