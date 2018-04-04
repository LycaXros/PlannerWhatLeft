
using DataEntity.Model;
using System.Data.Entity;
using Unity;
using WhatLeftPlanning.Services;
using WhatLeftPlanning.UserManagement;
//using Prism.Events;

namespace WhatLeftPlanning.Startup
{
    public static class Bootstrapper
    {

        private static IUnityContainer _container;

        static Bootstrapper()
        {
            _container = new UnityContainer();
            _container.RegisterType<IUnidadTrabajo, UnidadTrabajo>(
                    new Unity.Lifetime.ContainerControlledLifetimeManager());
            _container.RegisterType<PlanningOther>(
                new Unity.Lifetime.ContainerControlledLifetimeManager());
        }
        public static IUnityContainer Container => _container;
    }
}

