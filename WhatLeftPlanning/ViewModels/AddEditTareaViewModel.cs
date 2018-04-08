using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using DataEntity.Model;
using DevExpress.Mvvm;
using WhatLeftPlanning.Services;
using WhatLeftPlanning.SimpleItems;
using WhatLeftPlanning.Startup;

namespace WhatLeftPlanning.ViewModels
{
    public class AddEditTareaViewModel : ViewModelBase
    {

        private Tarea _editingTarea;
        private IUnidadTrabajo _unidadTrabajo;
        private SimpleTarea _currentTarea;

        public RelayCommand SaveCommand { get; }
        public RelayCommand CancelCommand { get; }


        public AddEditTareaViewModel(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        public event Action Done = delegate { };
        private DateTime _selectedDate;

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set { SetProperty(ref _selectedDate, value); }
        }



        private void OnCancel()
        {
            TipoID = 0;

            Done();
        }

        private async void OnSave()
        {

            UpdateCustomer(CurrentTarea, _editingTarea);
            if (EditMode)
            {

            }
            else
            {
                var detalle = new Tarea_Detalle
                {
                    FechaIni = DateTime.Now
                };
                if (IsTemporal)
                    detalle.FechaFin = SelectedDate;

                detalle.Usuario.Add(DatosEstaticos.CurrentUser);
                detalle.Estado = DataEntity.DataTransform.TareaDetalleEstados.Incompleta;

                await Task.Factory.StartNew(() => System.Threading.Thread.Sleep(1000));

                _editingTarea.Detalles.Add(detalle);
                _editingTarea.Estado = DataEntity.DataTransform.TareaEstados.Activa;
                _unidadTrabajo.Tareas.Add(_editingTarea);
            }
            Done();
        }

        private void UpdateCustomer(SimpleTarea source, Tarea tarea)
        {
            tarea.Nombre = source.Nombre;
            tarea.Descripción = source.Descripción;
            tarea.TipoID = source.TipoID;
        }

        private bool CanSave()
        {
            return !CurrentTarea.HasErrors;
        }

        //public AddEditTareaViewModel()
        //{

        //}
        private int _tipoID;

        public int TipoID
        {
            get { return _tipoID; }
            set
            {
                CurrentTarea.TipoID = value;
                SetProperty(ref _tipoID, value);
                IsTemporal = (value == DataEntity.DataTransform.Constantes.TipoTareaTemporal);                
            }
        }

        private bool editMode;

        private bool _isTemporal;

        public bool IsTemporal
        {
            get { return _isTemporal; }
            set { SetProperty(ref _isTemporal, value); }
        }

        public bool EditMode
        {
            get { return editMode; }
            set { SetProperty(ref editMode, value); }
        }

        public void SetTarea(Tarea obj)
        {
            _editingTarea = obj;
            if (CurrentTarea != null) CurrentTarea.ErrorsChanged -= RaiseCanExecuteChanged;
            CurrentTarea = new SimpleTarea();
            CurrentTarea.ErrorsChanged += RaiseCanExecuteChanged;
            CopyTarea(obj, CurrentTarea);
        }

        private void CopyTarea(Tarea source, SimpleTarea tarea)
        {
            tarea.ID = source.ID;
            if (EditMode)
            {
                tarea.Nombre = source.Nombre;
                tarea.Descripción = source.Descripción;
                tarea.TipoID = source.TipoID;
                TipoID = source.TipoID;
            }
        }

        private void RaiseCanExecuteChanged(object sender, DataErrorsChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public DateTime CurrentDate => DateTime.Now;

        public SimpleTarea CurrentTarea
        {
            get { return _currentTarea; }
            set { SetProperty(ref _currentTarea, value); }
        }

        public IEnumerable<Tipo_Tarea> TipoItems
        {
            get
            {
                return _unidadTrabajo.Tareas.ObtenerTipos();
            }
        }

    }
}