using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatLeftPlanning.SimpleItems
{
    public class SimpleTarea : ValidateViewModelBase
    {
        private int _id;
        private int _tipoID;
        private string _nombre;
        private string _descripción;

        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        [Required]
        public int TipoID { get => _tipoID; set => SetProperty(ref _tipoID, value); }

        [Required]
        [MaxLength(50, ErrorMessage = "Maxima longitud")]
        public string Nombre { get => _nombre; set => SetProperty(ref _nombre, value); }

        public string Descripción { get => _descripción; set => SetProperty(ref _descripción, value); }

    }
}
