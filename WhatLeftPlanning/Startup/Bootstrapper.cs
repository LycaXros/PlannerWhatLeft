
using Autofac;
using WhatLeftPlanning.UserManagement;
//using Prism.Events;

namespace WhatLeftPlanning.Startup
{
    public class Bootstrapper
    {
        private Bootstrapper() { }

        private static Bootstrapper _bootstrapper = null;
        private static IContainer _container = null;

        public static Bootstrapper Instance()
        {
                if (_bootstrapper == null)
                    _bootstrapper = new Bootstrapper();
                return _bootstrapper;
         
        }


        public IContainer Bootstrap()
        {
            if (_container == null)
            {
                var builder = new ContainerBuilder();


                builder.RegisterType<MainWindow>().AsSelf().SingleInstance();
                builder.RegisterType<MainViewModel>().AsSelf();

                builder.RegisterType<LoginForm>().AsSelf().SingleInstance();
                builder.RegisterType<LoginFormViewModel>().AsSelf();

                _container = builder.Build();
            }
            return _container;
            

        }
    }
}
