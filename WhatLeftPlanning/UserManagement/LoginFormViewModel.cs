using DevExpress.Mvvm;
using DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatLeftPlanning.Services;
using System.Windows;
using WhatLeftPlanning.Startup;
using Autofac;

namespace WhatLeftPlanning.UserManagement
{
    public class LoginFormViewModel : ViewModelBase, ISupportServices
    {

        #region Private members
        private LoginForm _loginForm;

        private IUnidadTrabajo _repo = null;
        private string _userNick;
        private string _password;
        private IServiceContainer _serviceContainer;

        #endregion
        #region Private Functions

        private async void OnLogin()
        {
            IsLogin = true;
            bool result = await _repo.Usuarios.ValidarCredencialesAsync(_userNick, _password);

            if (result)
            {
                //_messageDialogService.ShowDialog("Usuario Valido","Mensaje");
                MessageBoxService.ShowMessage("Usuario Valido", "Mensaje");

                var user = await _repo.Usuarios.GetUser(_userNick, _password);
                DatosEstaticos.CurrentUser = user;

                var mainWindow = new MainWindow();


                UserName = string.Empty;
                Password = string.Empty;
                _loginForm.Hide();
                mainWindow.ShowDialog();
                _loginForm.Visibility = Visibility.Visible;
                _loginForm.Show();
            }
            else
            {
                MessageBoxService.ShowMessage("Usuario No valido, Contraseña Incorrecta", "Mensaje");
            }
            IsLogin = false;
        }


        private bool CanLogin()
        {
            return !IsLogin;
        }

        private void OnCancel()
        {
            MessageBoxService.ShowMessage("Cerrando Aplicacion", "Mensaje urgente");
            System.Windows.Application.Current.Shutdown();
        }

        #endregion
        protected virtual IMessageBoxService MessageBoxService => ServiceContainer.GetService<IMessageBoxService>();

        public LoginFormViewModel(
            LoginForm loginForm,
            IUnidadTrabajo unidadTrabajo)
        {
            //_messageDialogService = messageDialogService;
            _loginForm = loginForm;
            _repo = unidadTrabajo;
            CancelCommand = new RelayCommand(OnCancel);
            LoginCommand = new RelayCommand(OnLogin, CanLogin);

            IsLogin = false;
            UserName = string.Empty;
            Password = string.Empty;
        }

        private bool _isLogin;

        public bool IsLogin
        {
            get { return _isLogin; }
            set
            {
                SetProperty(ref _isLogin, value);

                LoginCommand.RaiseCanExecuteChanged();
            }
        }


        public string UserName
        {
            get { return _userNick; }
            set { SetProperty(ref _userNick, value);
            }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value);
            }
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand LoginCommand { get; private set; }

        public IServiceContainer ServiceContainer
        {
            get
            {
                if (_serviceContainer == null)
                    _serviceContainer = new ServiceContainer(this);
                return _serviceContainer;
            }
        }
    }
}
