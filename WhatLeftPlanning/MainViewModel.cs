
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WhatLeftPlanning.Startup;
using DevExpress.Xpf.Ribbon;
using WhatLeftPlanning.Services;
using DataEntity.DataTransform;
using WhatLeftPlanning.ViewModels;
using WhatLeftPlanning.Views;
using DataEntity.Model;

namespace WhatLeftPlanning
{
    public class MainViewModel : ViewModelBase
    {
        #region Variables Privadas

        private ViewModelBase _currentViewModel;
        private IUnidadTrabajo _unidadTrabajo;
        private AddEditTareaViewModel _addEditTareaView;
        private ListaTareasViewModel _listaTareasView;

        #endregion

        public MainViewModel() { }
        public MainViewModel(
            IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
            _listaTareasView = new ListaTareasViewModel(unidadTrabajo);
            _listaTareasView.CompletarTareaEvent += SaveContext;
            _listaTareasView.EditarTareaEvent += EditarTarea;

            _addEditTareaView = new AddEditTareaViewModel(unidadTrabajo);
            _addEditTareaView.Done += SaveContext;

            _manejoUsuariosView = new ManejoUsuariosViewModel(unidadTrabajo);
            _manejoUsuariosView.Done += SaveContext;

            NavCommand = new RelayCommand<string>(OnNav, CanNav);
            ShowReportCommand = new RelayCommand<string>(ShowReport, CanNav);
            CurrentViewModel = _listaTareasView;
            //    HamburgerMenuItems = new ReadOnlyCollection<IHamburgerMenuItemViewModel>(InitializeMenuItems());
            //    HamburgerMenuBottomBarItems = new ReadOnlyCollection<IHamburgerMenuBottomBarItemViewModel>(InitializeBottomBarItems());

        }

        #region Funciones Privadas

        private void OnNav(string obj)
        {
            switch (obj)
            {
                case "nuevaTarea":
                    NavToNuevaTarea();
                    break;
                case "manejoUsuario":
                    NavToManejoUsuario();
                    break;
                case "listaTareas":
                default:
                    CurrentViewModel = _listaTareasView;
                    break;
            }
        }

        private void NavToManejoUsuario()
        {
            CurrentViewModel = _manejoUsuariosView;
        }

        private void NavToNuevaTarea()
        {
            _addEditTareaView.EditMode = false;
            _addEditTareaView.SetTarea(new DataEntity.Model.Tarea());
            CurrentViewModel = _addEditTareaView;
        }

        private bool CanNav(string arg)
        {
            var roles = DatosEstaticos.CurrentUser.ObtenerRoles();

            if (roles.Contains("Administrador"))
            {
                var actions = new[] { "listaTareas", "nuevaTarea", "asignarGrupos", "manejoUsuario", "setTareas", "adminGroup", "newGroup", "verReportes" };
                return actions.Contains(arg);

            }
            else if (roles.Contains("Lider"))
            {
                var actions = new[] { "listaTareas", "nuevaTarea", "asignarGrupos", "setTareas", "adminGroup", "newGroup", "verReportes" };
                return actions.Contains(arg);

            }
            else if (roles.Contains("Normal"))
            {
                var actions = new[] { "listaTareas", "nuevaTarea", "verReportes" };
                return actions.Contains(arg);

            }
            else
                return false;


        }

        private void EditarTarea(Tarea_Detalle tareaEditar)
        {
            _addEditTareaView.EditMode = true;
            _addEditTareaView.SetTarea(tareaEditar.Tarea, tareaEditar.ID);
            CurrentViewModel = _addEditTareaView;
        }

        private void ShowReport(string obj)
        {
            var reportWindow = new ReportWindows();
            reportWindow.ShowDialog();
        }

        private async void SaveContext()
        {
            await _unidadTrabajo.Complete();
            OnNav("listaTareas");
        }

        #endregion

        #region Metodos Publicos

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public string UserInfo =>
            $"{DatosEstaticos.CurrentUser.Nick} ({DatosEstaticos.CurrentUser.Nombre} {DatosEstaticos.CurrentUser.Apellido} )";

        private ManejoUsuariosViewModel _manejoUsuariosView;

        public RelayCommand<string> NavCommand { get; private set; }

        public RelayCommand<string> ShowReportCommand { get; }

        #endregion
    }
}
