using DataEntity.Model;
using DevExpress.Mvvm.DataAnnotations;
using TestViewApp.Localization;

namespace TestViewApp.PlanningOtherDataModel {

    public class PlanningOtherMetadataProvider {
		        public static void BuildMetadata(MetadataBuilder<Grupo> builder) {
			builder.DisplayName(PlanningOtherResources.Grupo);
						builder.Property(x => x.ID).DisplayName(PlanningOtherResources.Grupo_ID);
						builder.Property(x => x.Nombre).DisplayName(PlanningOtherResources.Grupo_Nombre);
						builder.Property(x => x.Descripcion).DisplayName(PlanningOtherResources.Grupo_Descripcion);
						builder.Property(x => x.FechaCreacion).DisplayName(PlanningOtherResources.Grupo_FechaCreacion);
			        }
		        public static void BuildMetadata(MetadataBuilder<Rol> builder) {
			builder.DisplayName(PlanningOtherResources.Rol);
						builder.Property(x => x.ID).DisplayName(PlanningOtherResources.Rol_ID);
						builder.Property(x => x.Nombre).DisplayName(PlanningOtherResources.Rol_Nombre);
			        }
		        public static void BuildMetadata(MetadataBuilder<Tarea> builder) {
			builder.DisplayName(PlanningOtherResources.Tarea);
						builder.Property(x => x.ID).DisplayName(PlanningOtherResources.Tarea_ID);
						builder.Property(x => x.Nombre).DisplayName(PlanningOtherResources.Tarea_Nombre);
						builder.Property(x => x.Descripción).DisplayName(PlanningOtherResources.Tarea_Descripción);
						builder.Property(x => x.Estado).DisplayName(PlanningOtherResources.Tarea_Estado);
						builder.Property(x => x.Tipo).DisplayName(PlanningOtherResources.Tarea_Tipo);
			        }
		        public static void BuildMetadata(MetadataBuilder<Tarea_Detalle> builder) {
			builder.DisplayName(PlanningOtherResources.Tarea_Detalle);
						builder.Property(x => x.ID).DisplayName(PlanningOtherResources.Tarea_Detalle_ID);
						builder.Property(x => x.FechaIni).DisplayName(PlanningOtherResources.Tarea_Detalle_FechaIni);
						builder.Property(x => x.FechaFin).DisplayName(PlanningOtherResources.Tarea_Detalle_FechaFin);
						builder.Property(x => x.Estado).DisplayName(PlanningOtherResources.Tarea_Detalle_Estado);
						builder.Property(x => x.Tarea).DisplayName(PlanningOtherResources.Tarea_Detalle_Tarea);
			        }
		        public static void BuildMetadata(MetadataBuilder<Tipo_Tarea> builder) {
			builder.DisplayName(PlanningOtherResources.Tipo_Tarea);
						builder.Property(x => x.ID).DisplayName(PlanningOtherResources.Tipo_Tarea_ID);
						builder.Property(x => x.Nombre).DisplayName(PlanningOtherResources.Tipo_Tarea_Nombre);
			        }
		        public static void BuildMetadata(MetadataBuilder<Usuario> builder) {
			builder.DisplayName(PlanningOtherResources.Usuario);
						builder.Property(x => x.ID).DisplayName(PlanningOtherResources.Usuario_ID);
						builder.Property(x => x.Nombre).DisplayName(PlanningOtherResources.Usuario_Nombre);
						builder.Property(x => x.Apellido).DisplayName(PlanningOtherResources.Usuario_Apellido);
						builder.Property(x => x.Nick).DisplayName(PlanningOtherResources.Usuario_Nick);
						builder.Property(x => x.Contraseña).DisplayName(PlanningOtherResources.Usuario_Contraseña);
			        }
		        public static void BuildMetadata(MetadataBuilder<UsuarioGrupo> builder) {
			builder.DisplayName(PlanningOtherResources.UsuarioGrupo);
						builder.Property(x => x.TipoIntegrante).DisplayName(PlanningOtherResources.UsuarioGrupo_TipoIntegrante);
						builder.Property(x => x.Grupo).DisplayName(PlanningOtherResources.UsuarioGrupo_Grupo);
						builder.Property(x => x.Usuario).DisplayName(PlanningOtherResources.UsuarioGrupo_Usuario);
			        }
		    }
}