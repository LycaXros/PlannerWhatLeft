using Autofac;
using System;
using System.Windows;
using WhatLeftPlanning.Startup;
using WhatLeftPlanning.UserManagement;

namespace WhatLeftPlanning
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var boostrapper = new Bootstrapper();
            var container = boostrapper.Bootstrap();
            var loginWindow = container.Resolve<LoginForm>();
            loginWindow.Show();
        }

        private void Application_DispatcherUnhandledException(object sender,
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Error inesperado. Informe al administrado de sistema."
                + Environment.NewLine + e.Exception.Message, "ERROR!");
            e.Handled = true;

        }
    }
}
