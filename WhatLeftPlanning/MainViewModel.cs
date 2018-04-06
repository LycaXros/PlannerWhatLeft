
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WhatLeftPlanning.Startup;
using DevExpress.Xpf.Ribbon;
using WhatLeftPlanning.Services;
using DataEntity.DataTransform;
using WhatLeftPlanning.ViewModels;

namespace WhatLeftPlanning
{
    public class MainViewModel : ViewModelBase
    {

        private ViewModelBase _currentViewModel;
        private IUnidadTrabajo _unidadTrabajo;
        private ListaTareasViewModel _listaTareasView;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }


        public string UserInfo =>
            $"{DatosEstaticos.CurrentUser.Nick} ({DatosEstaticos.CurrentUser.Nombre} {DatosEstaticos.CurrentUser.Apellido} )";

        public MainViewModel() { }
        public MainViewModel(
            IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
            _listaTareasView = new ListaTareasViewModel(unidadTrabajo);
            _listaTareasView.CompletarTareaEvent += SaveContext;

            _addEditTareaView = new AddEditTareaViewModel(unidadTrabajo);
            _addEditTareaView.Done += SaveContext;

            NavCommand = new RelayCommand<string>(OnNav, CanNav);
            CurrentViewModel = _listaTareasView;
            //    HamburgerMenuItems = new ReadOnlyCollection<IHamburgerMenuItemViewModel>(InitializeMenuItems());
            //    HamburgerMenuBottomBarItems = new ReadOnlyCollection<IHamburgerMenuBottomBarItemViewModel>(InitializeBottomBarItems());

        }

        private async void SaveContext()
        {
            await _unidadTrabajo.Complete();
            OnNav("listaTareas");
        }

        private void OnNav(string obj)
        {
            switch (obj)
            {
                case "nuevaTarea":
                    NavToNuevaTarea();
                    break;
                case "listaTareas":
                default:
                    CurrentViewModel = _listaTareasView;
                    break;
            }
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
                var actions =new[]{ "listaTareas", "nuevaTarea", "asignarGrupos","nuevoUsuario","setTareas", "adminGroup","newGroup", "verReportes" };
                return actions.Contains(arg);

            }
            else if (roles.Contains("Lider"))
            {
                var actions = new[] { "listaTareas", "nuevaTarea", "asignarGrupos","setTareas", "adminGroup", "newGroup", "verReportes" };
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

        private void InitializeRibbonControlItems()
        {
        }

        private AddEditTareaViewModel _addEditTareaView;

        public RelayCommand<string> NavCommand { get; private set; }
        

    }
}
