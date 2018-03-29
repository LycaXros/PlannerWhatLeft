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
    public class LoginFormViewModel : ViewModelBase
    {
        private IMessageDialogService _messageDialogService;
        private LoginForm _loginForm;
        #region Private members

        private IUserRepository _repo = null;
        private string _userNick;
        private string _password;

        #endregion

        public LoginFormViewModel(IMessageDialogService messageDialogService,
            LoginForm loginForm)
        {
            _messageDialogService = messageDialogService;
            _loginForm = loginForm;
            _repo = new UserRepository();
            CancelCommand = new RelayCommand(OnCancel);
            LoginCommand = new RelayCommand(OnLogin);
        }

        private async void OnLogin()
        {
            bool result = await _repo.ValidarCredencialesAsync(_userNick, _password);

            if (result)
            {
                _messageDialogService.ShowDialog("Usuario Valido","Mensaje");


                var boostrapper = new Bootstrapper();
                var container = boostrapper.Bootstrap();
                var mainWindow = container.Resolve<MainWindow>();


                UserName = string.Empty;
                Password = string.Empty;
                _loginForm.Hide();
                mainWindow.ShowDialog();
                _loginForm.Visibility = Visibility.Visible;
                _loginForm.Show();
            }
            else
            {
                _messageDialogService.ShowDialog("Usuario No valido", "Mensaje");
            }
        }

        private void OnCancel()
        {
            System.Windows.MessageBox.Show("Cerrando Aplicacion", "Mensaje urgente");
            System.Windows.Application.Current.Shutdown();
        }

        public string UserName
        {
            get { return _userNick; }
            set { SetProperty(ref _userNick, value ); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password , value); }
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand LoginCommand { get; private set; }
    }
}
