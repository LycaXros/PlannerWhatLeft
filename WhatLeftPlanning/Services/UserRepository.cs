using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;

namespace WhatLeftPlanning.Services
{
    public class UserRepository : IUserRepository
    {
        public PlanningDBEntities _context = null;

        public UserRepository()
        {
            _context = new PlanningDBEntities();
        }

        public async Task<Usuario> AñadirUsuarioAsync(Usuario user)
        {
            _context.Usuario.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task EliminarUsuarioAsync(int id)
        {
            var user = _context.Usuario.FirstOrDefault(u => u.ID.Equals(id));
            if (user != null)
            {
                _context.Usuario.Remove(user);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> ModificarUsuarioAsync(Usuario user)
        {
            if (!_context.Usuario.Local.Any(c => c.ID == user.ID))
            {
                _context.Usuario.Attach(user);
            }
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<Usuario> ObtenerUsuarioAsync(int id)
        {
            return _context.Usuario.FirstOrDefaultAsync(c => c.ID == id);
        }

        public Task<List<Usuario>> ObtenerListaUsuariosAsync()
        {
            return _context.Usuario.ToListAsync();
        }

        public async Task<bool> ValidarCredencialesAsync(string nick, string pass)
        {

            var userExist = await _context.Usuario
                .AnyAsync(x => x.Nick.Equals(nick));
            var passConverted = Encriptador.Encriptar(pass);

            try
            {
                var dataConfig = (DataEntity.XmlConfig.DataSection)System.Configuration.ConfigurationManager
                        .GetSection("customData/dataEntry");
                var savedPass = dataConfig.Entry.Value;

            }
            catch (Exception ex)
            {   }
            if (userExist)
            {
                var dbPass = await _context.Usuario
                    .Where(x => x.Nick.Equals(nick))
                    .Select(x => x.Contraseña)
                    .FirstAsync();

                var decryptedPass = Encriptador.Desencriptar(dbPass);
                return pass.Equals(decryptedPass);

                //&& x.Contraseña.Equals(pass)
            }

            return false;
        }
    }
}