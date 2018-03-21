using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;

namespace WhatLeftPlanning.Services
{
    public interface IUserRepository
    {
        Task<List<Usuario>> ObtenerListaUsuariosAsync();
        Task<bool> ValidarCredencialesAsync(string nick, string pass);

        Task<Usuario> ObtenerUsuarioAsync(int id);
        Task<Usuario> AñadirUsuarioAsync(Usuario user);
        Task<Usuario> ModificarUsuarioAsync(Usuario user);
        Task EliminarUsuarioAsync(int id);
    }
}
