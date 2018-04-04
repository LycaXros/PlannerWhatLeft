using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataEntity.Model;
using DevExpress.Mvvm;
using WhatLeftPlanning.Services;

namespace WhatLeftPlanning.ViewModels
{
    public class ListaTareasViewModel : ViewModelBase, ISupportServices
    {
        private IServiceContainer _serviceContainer;
        private IUnidadTrabajo _unidadTrabajo;

        public RelayCommand EliminarCommand { get; }
        public RelayCommand EditarCommand { get; }

        private List<Tarea> _tareasUsuario;
        private ObservableCollection<Tarea> _tareas;

        private Tarea _selected;

        public Tarea SelectedTarea
        {
            get { return _selected; }
            set { _selected = value;
                EliminarCommand.RaiseCanExecuteChanged();
                EditarCommand.RaiseCanExecuteChanged();
            }
        }

        public event Action<Tarea> EditarTareaEvent = delegate { };

        public ObservableCollection<Tarea> Tareas
        {
            get => _tareas;
            set => SetProperty(ref _tareas, value);
        }

        public ListaTareasViewModel(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
            EliminarCommand = new RelayCommand(OnDelete, CanDoChanges);
            EditarCommand = new RelayCommand(OnEdit, CanDoChanges);
        }

        private void OnEdit()
        {
            EditarTareaEvent(_selected);
        }

        private void OnDelete()
        {
            var r = MessageBoxService.ShowMessage("Desea Borrar Esta Tarea?", "Eliminado", MessageButton.YesNo);
            if(r == MessageResult.Yes)
            {
                //_unidadTrabajo.
            }
        }

        private bool CanDoChanges()
        {
            return _selected != null;
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
            var r = await _unidadTrabajo.Usuarios.ObtenerTareasUsuarioActual();
            
            _tareasUsuario =  (List<Tarea>) r;
            Tareas = new ObservableCollection<Tarea>(_tareasUsuario);
        }
    }
}