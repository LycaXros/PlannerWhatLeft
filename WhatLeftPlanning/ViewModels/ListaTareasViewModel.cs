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
        public RelayCommand CompletarCommand { get; }

        private List<Tarea_Detalle> _tareasUsuario;
        private ObservableCollection<Tarea_Detalle> _tareas;

        private Tarea_Detalle _selected;

        public Tarea_Detalle SelectedTarea
        {
            get { return _selected; }
            set { _selected = value;
                EliminarCommand.RaiseCanExecuteChanged();
                EditarCommand.RaiseCanExecuteChanged();
                CompletarCommand.RaiseCanExecuteChanged();
            }
        }

        public event Action<Tarea_Detalle> EditarTareaEvent = delegate { };
        public event Action CompletarTareaEvent = delegate { };

        public ObservableCollection<Tarea_Detalle> Tareas
        {
            get => _tareas;
            set => SetProperty(ref _tareas, value);
        }
        //public ListaTareasViewModel(){ }
        public ListaTareasViewModel(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
            EliminarCommand = new RelayCommand(OnDelete, CanDoChanges);
            EditarCommand = new RelayCommand(OnEdit, CanDoChanges);
            CompletarCommand = new RelayCommand(OnComplete, CanDoChanges);
        }

        private async void OnComplete()
        {
            SelectedTarea.Estado = "C";
            SelectedTarea.FechaFin = DateTime.Now;
            await _unidadTrabajo.Complete();
            LoadTareas();
        }

        private void OnEdit()
        {
            EditarTareaEvent(_selected);
        }

        private async void OnDelete()
        {
            var r = MessageBoxService.ShowMessage("Desea Borrar Esta Tarea?", "Eliminado", MessageButton.YesNo);
            if(r == MessageResult.Yes)
            {
                _unidadTrabajo.TareasDetalle.Remove(SelectedTarea);
                await _unidadTrabajo.Complete();
                LoadTareas();
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
            var r = await _unidadTrabajo.TareasDetalle.ObtenerTareasUsuarioActual();
            
            _tareasUsuario =  (List<Tarea_Detalle>) r;
            Tareas = null;
            Tareas = new ObservableCollection<Tarea_Detalle>(_tareasUsuario);
        }
    }
}