
using Autofac;
using WhatLeftPlanning.Services;
using WhatLeftPlanning.UserManagement;
//using Prism.Events;

namespace WhatLeftPlanning.Startup
{
    public class Bootstrapper
    {
        public Bootstrapper() { }



        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();


            builder.RegisterType<MainWindow>().AsSelf().SingleInstance();
            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();
            builder.RegisterType<UnidadTrabajo>().As<IUnidadTrabajo>();

            builder.RegisterType<DataEntity.Model.PlanningOther>().AsSelf();

            builder.RegisterType<LoginForm>().AsSelf().SingleInstance();
            builder.RegisterType<LoginFormViewModel>().AsSelf().SingleInstance();

            return builder.Build();



        }
    }
}
