using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatLeftPlanning.UserManagement
{
    public class LoginFormViewModel : BindableBase
    {
        private string _userNick;

        public string UserName
        {
            get { return _userNick; }
            set { SetProperty(() => _userNick, value ); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { SetProperty(() =>_password , value); }
        }


    }
}
