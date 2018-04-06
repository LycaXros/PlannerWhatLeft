using DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatLeftPlanning.Services
{
    public class TareaRepository : Repositorio<Tarea>, ITareaRepository
    {
        public TareaRepository(PlanningOther context) : base(context)
        {
        }

        public PlanningOther PlanningDb
        {
            get => Context as PlanningOther;
        }

        public IEnumerable<Tipo_Tarea> ObtenerTipos()
        {
            return PlanningDb.Tipo_Tarea.ToList();
        }
    }
}
