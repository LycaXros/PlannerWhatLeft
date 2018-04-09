using System.Threading.Tasks;
using DataEntity.Model;

namespace WhatLeftPlanning.Services
{
    public interface IGrupoRepository : IRepositorio<Grupo>
    {
        Task AsignarUsuario(Usuario usuario, Grupo grupo);
        Task<int> UsuariosPorGrupo(Grupo grupo);
    }
}