﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataEntity.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PlanningOther : DbContext
    {
        public PlanningOther()
            : base("name=PlanningOther")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Tarea> Tarea { get; set; }
        public virtual DbSet<Tarea_Detalle> Tarea_Detalle { get; set; }
        public virtual DbSet<Tipo_Tarea> Tipo_Tarea { get; set; }
        public virtual DbSet<UsuarioGrupo> UsuarioGrupo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
    }
}
