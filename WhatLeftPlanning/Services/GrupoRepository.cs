using DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhatLeftPlanning.Services
{
    public class GrupoRepository : Repositorio<Grupo>, IGrupoRepository
    {
        public GrupoRepository(PlanningOther context) : base(context)
        {

        }

        public async Task AsignarUsuario(Usuario usuario, Grupo grupo )
        {

            var lista = (Context as PlanningOther).UsuarioGrupo;

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
