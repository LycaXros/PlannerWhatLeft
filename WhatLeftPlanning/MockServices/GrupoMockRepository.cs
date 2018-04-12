using DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhatLeftPlanning.Services;

namespace WhatLeftPlanning.MockServices
{
    public class GrupoMockRepository : MockRepositorio<Grupo>, IGrupoRepository
    {
        public GrupoMockRepository(Dictionary<Type, object> context) : base(context)
        {

        }

        public async Task AsignarUsuario(Usuario usuario, Grupo grupo )
        {

            var lista = Context[typeof(UsuarioGrupo)] as List<UsuarioGrupo>;

            lista.Add(new UsuarioGrupo()
            {
                Grupo = grupo,
                Usuario = usuario,
                TipoIntegrante = DataEntity.DataTransform.Constantes.GrupoUsuarioNormal
            });

            await Task.Run(() => Thread.Sleep(1000));
        }

        public async Task<int> UsuariosPorGrupo(Grupo grupo)
        {
            await Task.Run(() => Thread.Sleep(100));
            return grupo.UsuariosRef.Count();
        }
    }
}
