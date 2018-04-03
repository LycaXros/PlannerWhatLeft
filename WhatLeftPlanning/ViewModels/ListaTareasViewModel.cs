using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataEntity.Model;
using DevExpress.Mvvm;
using WhatLeftPlanning.Services;

namespace WhatLeftPlanning.ViewModels
{
    public class ListaTareasViewModel : DevExpress.Mvvm.ViewModelBase, ISupportServices
    {
        private IServiceContainer _serviceContainer;
        private IUnidadTrabajo _unidadTrabajo;
        private List<Tarea> _tareasUsuario;
        private ObservableCollection<Tarea> _tareas;

        public ObservableCollection<Tarea> Tareas
        {
            get => _tareas;
            set => SetProperty(ref _tareas, value, nameof(Tareas));
        }

        public ListaTareasViewModel(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }


        public IServiceContainer ServiceContainer
        {
            get
            {
                if (_serviceContainer == null)
                    _serviceContainer = new ServiceContainer(this);
                return _serviceContainer;
            }
        }

        protected virtual IMessageBoxService MessageBoxService => ServiceContainer.GetService<IMessageBoxService>();

        public async void LoadTareas()
        {
            _tareasUsuario = (await _unidadTrabajo.Usuarios.ObtenerTareasUsuarioActual()) as List<Tarea>;
            Tareas = new ObservableCollection<Tarea>(_tareasUsuario);
        }
    }
}