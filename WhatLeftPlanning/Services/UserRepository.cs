using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity.DataTransform;
using DataEntity.Model;

namespace WhatLeftPlanning.Services
{
    public class UserRepository : Repositorio<Usuario>, IUserRepository
    {
        public UserRepository(PlanningOther context)
            :base(context)
        {
        }

        public async Task<bool> ValidarCredencialesAsync(string nick, string pass)
        {

            var userExist = await dbSet
                .AnyAsync(x => x.Nick.Equals(nick));

            var passConverted = Encriptador.Encriptar(pass);

            try
            {
                var dataConfig = System.Configuration.ConfigurationManager
                        .GetSection("customData");
                var savedPass = (dataConfig as DataEntity.XmlConfig.DataSection).Instances["AdminCodPass"].Value;

            }
            catch (Exception ex)
            {   }

            if (userExist)
            {
                var dbPass = await dbSet
                    //.Where(x => x.Nick.Equals(nick))
                    //.Select(x => x.Contraseña)
                    .FirstAsync(x => x.Nick.Equals(nick));

                var decryptedPass = Encriptador.Desencriptar(dbPass.Contraseña);
                return pass.Equals(decryptedPass);

                //&& x.Contraseña.Equals(pass)
            }

            return false;
        }

        public async Task<Usuario> GetUser(string nick, string pass)
        {
            var passConverted = Encriptador.Encriptar(pass);

            return await  dbSet
                .FirstOrDefaultAsync(x => x.Nick.Equals(nick) && passConverted.Equals(x.Contraseña) );
        }

        public PlanningOther PlanningDb
        {
            get => Context as PlanningOther;
        }
    }
}