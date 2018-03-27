using Autofac;
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
            var boostrapper = Bootstrapper.Instance();
            var container = boostrapper.Bootstrap();
            var loginWindow = container.Resolve<LoginForm>();
            loginWindow.Show();
        }
    }
}
