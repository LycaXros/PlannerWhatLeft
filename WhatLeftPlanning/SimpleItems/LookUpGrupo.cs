namespace WhatLeftPlanning.SimpleItems
{
    public class LookUpGrupo : ValidateViewModelBase
    {
        private string _nombre;
        private int _total;
        private int _id;
        private string _descripcion;

        public string Nombre
        {
            get => _nombre; set
            {
                SetProperty(ref _nombre, value);
                OnPropertyChanged("FullDesc");
            }
        }
        public int Id { get => _id; set => _id = value; }

        public int Total
        {
            get => _total; set
            {
                SetProperty(ref _total, value);
                OnPropertyChanged("FullDesc");
            }
        }

        public string Descripcion { get => _descripcion; set => SetProperty(ref _descripcion , value); }
        public string FullDesc => $"{Nombre}, Total Usuarios:{Total}";
    }
}