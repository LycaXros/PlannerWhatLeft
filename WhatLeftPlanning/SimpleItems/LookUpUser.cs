namespace WhatLeftPlanning.SimpleItems
{
    public class LookUpUser : ValidateViewModelBase
    {
        private string _nombre;
        private string _apellido;
        private string _nick;
        private int _id;

        public int ID
        {
            get => _id; set
            {
                SetProperty(ref _id, value);
                OnPropertyChanged("UserInfo");
            }
        }

        public string Nombre
        {
            get => _nombre; set
            {
                SetProperty(ref _nombre, value);
                OnPropertyChanged("UserInfo");
            }
        }
        public string Apellido
        {
            get => _apellido; set
            {
                SetProperty(ref _apellido, value);
                OnPropertyChanged("UserInfo");
            }
        }

        public string Nick
        {
            get => _nick; set
            {
                SetProperty(ref _nick, value);
                OnPropertyChanged("UserInfo");
            }
        }

        public string UserInfo =>
            $"{Nick} ({Nombre} {Apellido} )";
    }
}