using DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatLeftPlanning.Services
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly PlanningOther _context;
        private IUserRepository _usuarios;
        private ITareasDetalleRepository _tareasDetalle;
        private ITareaRepository _tareas;
        private IGrupoRepository _grupos;

        public UnidadTrabajo(PlanningOther context)
        {
            _context = context;
        }

        public IUserRepository Usuarios
        {
            get
            {
                if (_usuarios == null)
                    _usuarios = new UserRepository(_context);
                return _usuarios;
            }
        }

        public ITareasDetalleRepository TareasDetalle
        {
            get
            {
                if (_tareasDetalle == null)
                    _tareasDetalle = new TareasDetalleRepository(_context);
                return _tareasDetalle;
            }
        }

        public ITareaRepository Tareas
        {
            get
            {
                if (_tareas == null)
                    _tareas = new TareaRepository(_context);
                return _tareas;
            }
        }

        public IGrupoRepository Grupos
        {
            get
            {
                if (_grupos == null)
                    _grupos = new GrupoRepository(_context);
                return _grupos;
            }
        }

        public async Task<int> Complete()
        {

            int saving = 0;
            try
            {
                saving = await _context.SaveChangesAsync();
                RefreshAll();
                return saving;
            }
            catch (DbEntityValidationException ex)
            {
                RollBack();
                throw ex;
            }
            catch (Exception ex)
            {
                RollBack();
                throw ex;
            }

            
        }
        public PlanningOther GetContext()
        {
            return _context;

        }
        public void Dispose() => _context.Dispose();
        private void RefreshAll()
        {
            foreach (var entity in _context.ChangeTracker.Entries())
            {
                
                entity.Reload();
            }
        }
        private void RollBack()
        {
            var changedEntries = _context.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();
            
            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }

}
