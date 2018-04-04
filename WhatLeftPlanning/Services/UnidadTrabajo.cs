using DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatLeftPlanning.Services
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly PlanningOther _context;
        private IUserRepository _usuarios;

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

        public async Task<int> Complete() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();

    }
}
