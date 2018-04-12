using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity.Model;
using WhatLeftPlanning.Services;

namespace WhatLeftPlanning.MockServices
{
    public class MockUnidadTrabajo : IUnidadTrabajo
    {
        private readonly Dictionary<Type, object> _context;
        private IUserRepository _usuarios;
        private ITareasDetalleRepository _tareasDetalle;
        private ITareaRepository _tareas;
        private IGrupoRepository _grupos;

        public IUserRepository Usuarios
        {
            get
            {
                if (_usuarios == null)
                    _usuarios = new UserMockRepository(_context);
                return _usuarios;
            }
        }

        public ITareasDetalleRepository TareasDetalle
        {
            get
            {
                if (_tareasDetalle == null)
                    _tareasDetalle = new TareasDetalleMockRepository(_context);
                return _tareasDetalle;
            }
        }

        public ITareaRepository Tareas
        {
            get
            {
                if (_tareas == null)
                    _tareas = new TareaMockRepository(_context);
                return _tareas;
            }
        }

        public IGrupoRepository Grupos
        {
            get
            {
                if (_grupos == null)
                    _grupos = new GrupoMockRepository(_context);
                return _grupos;
            }
        }
        public MockUnidadTrabajo(Dictionary<Type, object> context)
        {
            _context = context;
        }
        public Task<int> Complete()
        {
            return Task.Run(() => 1);
        }

        public void Dispose()
        {
        }

        public PlanningOther GetContext()
        {
            throw new NotImplementedException();
        }
    }
}
