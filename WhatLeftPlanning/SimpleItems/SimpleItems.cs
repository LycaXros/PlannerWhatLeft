using DataEntity.Model;
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

        [Required(ErrorMessage = "El nombre de la tarea es necesario")]
        [MaxLength(50, ErrorMessage = "Maxima longitud")]
        public string Nombre { get => _nombre; set => SetProperty(ref _nombre, value); }

        public string Descripción { get => _descripción; set => SetProperty(ref _descripción, value); }

    }

    public class SimpleUsuario : ValidateViewModelBase
    {
        private int _iD;
        private string _nombre;
        private string _apellido;
        private string _nick;
        private string _contraseña;
        private string _confirmContraseña;
        private List<Rol> _roles;

        public int ID { get => _iD; set => SetProperty(ref _iD, value); }

        public string FullDesc => $"{Nick}( {Nombre} {Apellido})";

        [Required(ErrorMessage = "Se Necesita del nombre del usuario")]
        [MinLength(5, ErrorMessage = "Logitud debe de ser mayor a 5 caractores")]
        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es de 50 caracteres")]
        public string Nombre
        {
            get => _nombre; set
            {
                SetProperty(ref _nombre, value);
                OnPropertyChanged("FullDesc");
            }
        }

        [Required(ErrorMessage = "Se Necesita del Apellid del usuario")]
        [MinLength(5, ErrorMessage = "Logitud debe de ser mayor a 5 caractores")]
        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es de 50 caracteres")]
        public string Apellido
        {
            get => _apellido; set
            {
                SetProperty(ref _apellido, value);
                OnPropertyChanged("FullDesc");
                
            }
        }

        [Required(ErrorMessage = "Se Necesita del NICK del usuario")]
        [MinLength(5, ErrorMessage ="Logitud debe de ser mayor a 5 caractores")]
        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es de 50 caracteres")]
        public string Nick { get => _nick; set => SetProperty(ref _nick, value); }

        [Required(ErrorMessage = "Se Necesita de la contraseña del usuario")]
        [StringLength(255, ErrorMessage = "Debe de ser mayor a 5 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Contraseña { get => _contraseña; set => SetProperty(ref _contraseña, value, "Contraseña"); }

        [StringLength(255, ErrorMessage = "Debe de ser mayor a 5 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Contraseña",ErrorMessage ="Ambas contraseñas deben de ser iguales")]
        public string ConfirmContraseña { get => _confirmContraseña; set => SetProperty(ref _confirmContraseña, value,  "ConfirmContraseña"); }

        public List<Rol> Roles { get => _roles; set => SetProperty(ref _roles, value); }
        
    }

    public class SimpleGrupo: ValidateViewModelBase
    {
        private int _id;
        private string _nombre;
        private string _descripcion;

        public int ID { get => _id; set => SetProperty(ref _id , value); }

        [Required(ErrorMessage = "Se Necesita del Nombew del Grupo")]
        [StringLength(50, ErrorMessage = "Debe de ser mayor a 5  y menor de 50 caracteres", MinimumLength = 5)]
        public string Nombre { get => _nombre; set => SetProperty(ref _nombre , value); }

        public string Descripcion { get => _descripcion; set => SetProperty(ref _descripcion , value); }
    }
}
