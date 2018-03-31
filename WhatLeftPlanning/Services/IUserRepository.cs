using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity.Model;

namespace WhatLeftPlanning.Services
{
    public interface IUserRepository : IRepositorio<Usuario>
    {
        Task<bool> ValidarCredencialesAsync(string nick, string pass);
        Task<Usuario> GetUser(string nick, string pass);
    }
}
