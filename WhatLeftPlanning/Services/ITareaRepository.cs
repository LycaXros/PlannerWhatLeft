using DataEntity.Model;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WhatLeftPlanning.Services
{
    public  interface ITareaRepository : IRepositorio<Tarea>
    {
        IEnumerable<Tipo_Tarea> ObtenerTipos();
    }
}