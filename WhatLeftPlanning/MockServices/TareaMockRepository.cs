using DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatLeftPlanning.Services;

namespace WhatLeftPlanning.MockServices
{
    public class TareaMockRepository : MockRepositorio<Tarea>, ITareaRepository
    {
        public TareaMockRepository(Dictionary<Type, object> context) : base(context)
        {
        }


        public IEnumerable<Tipo_Tarea> ObtenerTipos()
        {
            return (Context[typeof(Tipo_Tarea)] as List<Tipo_Tarea>).ToList();
        }
    }
}
