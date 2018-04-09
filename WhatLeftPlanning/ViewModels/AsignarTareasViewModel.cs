using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataEntity.Model;
using DevExpress.Mvvm;
using WhatLeftPlanning.Services;
using WhatLeftPlanning.SimpleItems;
using WhatLeftPlanning.Startup;

namespace WhatLeftPlanning.ViewModels
{
    public class AsignarTareasViewModel : ViewModelBase
    {
        private List<System.Object> _selectedTareasID;
        private int _selectedUserId;
        private ObservableCollection<Tarea> _tareas;
        private IUnidadTrabajo _unidadTrabajo;

        private ObservableCollection<LookUpUser> _usuarios;

        public AsignarTareasViewModel()
        {

        }
        public AsignarTareasViewModel(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        public event Action Done = delegate { };

        private bool CanSave()
        {
            return SelectedTareasID == null ? false : SelectedTareasID.Count > 0;
        }

        private async void OnSave()
        {
            var user = await _unidadTrabajo.Usuarios.GetByID(SelectedUserID);
            foreach (var item in SelectedTareasID)
            {
                var detalle = new Tarea_Detalle
                {
                    FechaIni = DateTime.Now
                };
                detalle.Usuarios.Add(user);
                detalle.Estado = DataEntity.DataTransform.TareaDetalleEstados.Incompleta;

                int id = 0;
                if (int.TryParse(item.ToString(), out id))
                {
                    var tarea = await _unidadTrabajo.Tareas.GetByID(id);

                    tarea.Detalles.Add(detalle);
                }
            }
            
            //_editingTarea.Detalles.Add(detalle);
            //_editingTarea.Estado = DataEntity.DataTransform.TareaEstados.Activa;
            //_unidadTrabajo.Tareas.Add(_editingTarea);
            LoadTareas(SelectedUserID);
            Done();
        }

        private IEnumerable<LookUpUser> ToLookUpUser(List<Usuario> users)
        {
            List<LookUpUser> lookUps = new List<LookUpUser>();

            foreach (var item in users)
            {
                lookUps.Add(new LookUpUser()
                {
                    ID = item.ID,
                    Nick = item.Nick,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido
                });
            }

            return lookUps;
        }

        public async void LoadTareas(int id)
        {
            var user = await _unidadTrabajo.Usuarios.GetByID(id);

            var detallesUsuarios = user.DetalleTareas
                .Where(x => x.Estado.Equals(DataEntity.DataTransform.TareaDetalleEstados.Incompleta)).ToList();
            if(detallesUsuarios.Count < 1)
            {
                Tareas = new ObservableCollection<Tarea>(await
                    _unidadTrabajo.Tareas.GetAll());
                return;
            }

            var tareasAsignadas = detallesUsuarios.Select(x => x.Tarea).Distinct().ToList();

            var tareasFaltantes = (await _unidadTrabajo.Tareas.GetAll()).Where(x => !tareasAsignadas.Contains(x)).ToList();

            Tareas = new ObservableCollection<Tarea>(tareasFaltantes);

        }

        public async void LoadUsers()
        {
            var users = (await _unidadTrabajo.Usuarios.GetAll()).ToList();
            Usuarios = new ObservableCollection<LookUpUser>(ToLookUpUser(users));
        }

        public RelayCommand SaveCommand { get; }
        public List<System.Object> SelectedTareasID
        {
            get => _selectedTareasID; set
            {
                SetProperty(ref _selectedTareasID, value);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public int SelectedUserID
        {
            get => _selectedUserId; set
            {
                SetProperty(ref _selectedUserId, value);
                LoadTareas(_selectedUserId);
            }
        }

        public ObservableCollection<Tarea> Tareas
        {
            get => _tareas; private set
            {
                SetProperty(ref _tareas, value);
            }
        }

        public ObservableCollection<LookUpUser> Usuarios
        {
            get => _usuarios;
            private set => SetProperty(ref _usuarios, value);
        }
    }
}
