using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataEntity.DataTransform;
using DataEntity.Model;
using WhatLeftPlanning.Services;
using WhatLeftPlanning.Startup;

namespace WhatLeftPlanning.MockServices
{
    public class UserMockRepository : MockRepositorio<Usuario>, IUserRepository
    {
        public UserMockRepository(Dictionary<Type, object> context)
            :base(context)
        {
        }

        public async Task<bool> ValidarCredencialesAsync(string nick, string pass)
        {
            await Task.Run(() => Thread.Sleep(100));
            if (string.IsNullOrEmpty(nick) || string.IsNullOrEmpty(pass))
                return false;

            var userExist =  dbSet
                .Any(x => x.Nick.Equals(nick));

            var passConverted = Encriptador.Encriptar(pass);

            if (userExist)
            {
                var dbPass = dbSet
                    //.Where(x => x.Nick.Equals(nick))
                    //.Select(x => x.Contraseña)
                    .First(x => x.Nick.Equals(nick));

                var decryptedPass = Encriptador.Desencriptar(dbPass.Contraseña);
                return pass.Equals(decryptedPass);

                //&& x.Contraseña.Equals(pass)
            }

            return false;
        }

        public async Task<Usuario> GetUser(string nick, string pass)
        {
            await Task.Run(() => Thread.Sleep(100));
            var passConverted = Encriptador.Encriptar(pass);

            return  dbSet
                .FirstOrDefault(x => x.Nick.Equals(nick) && passConverted.Equals(x.Contraseña) );
        }


    }
}