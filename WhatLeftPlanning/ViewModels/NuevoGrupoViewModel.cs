using System;
using System.Collections.Generic;
using System.ComponentModel;
using DataEntity.Model;
using DevExpress.Mvvm;
using WhatLeftPlanning.Services;
using WhatLeftPlanning.SimpleItems;
using WhatLeftPlanning.Startup;

namespace WhatLeftPlanning.ViewModels
{
    public class NuevoGrupoViewModel : ViewModelBase
    {
        private SimpleGrupo _currentGrupo;
        private IUnidadTrabajo _unidadTrabajo;

        public RelayCommand CancelCommand { get; }
        public RelayCommand SaveCommand { get; }

        public event Action Done = delegate { };


        public NuevoGrupoViewModel()
        {

        }

        public NuevoGrupoViewModel(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
            _currentGrupo = new SimpleGrupo();

            SetGrupo( new Grupo());
        }
        public SimpleGrupo CurrentGrupo
        {
            get => _currentGrupo;
            set => SetProperty(ref _currentGrupo, value);
        }

        private void OnCancel()
        {
            Done();
        }

        private void OnSave()
        {
            var _grupo = new Grupo
            {
                UsuariosRef = new List<UsuarioGrupo>()
            };
            CopiarGrupo(CurrentGrupo, _grupo);

            var unionUsuario = new UsuarioGrupo()
            {
                Grupo = _grupo,
                Usuario = DatosEstaticos.CurrentUser,
                TipoIntegrante = DataEntity.DataTransform.Constantes.GrupoUsuarioLider
            };
            _unidadTrabajo.Grupos.Add(_grupo);
            _unidadTrabajo.GetContext().UsuarioGrupo.Add(unionUsuario);


            Done();
        }

        private void CopiarGrupo(SimpleGrupo source, Grupo target)
        {
            target.ID = source.ID;
            target.Nombre = source.Nombre;
            target.Descripcion = source.Descripcion;
            target.FechaCreacion = DateTime.Now;

        }

        private bool CanSave()
        {
            return !CurrentGrupo.HasErrors;
        }

        public void SetGrupo(Grupo grupo)
        {
            if (CurrentGrupo != null) CurrentGrupo.ErrorsChanged -= CurrentGrupoErrosChanged;
            CopyToSimpleGrupo(grupo, CurrentGrupo);
            CurrentGrupo.ErrorsChanged += CurrentGrupoErrosChanged;
        }

        private void CurrentGrupoErrosChanged(object sender, DataErrorsChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyToSimpleGrupo(Grupo source, SimpleGrupo target)
        {
            target.ID = source.ID;
            target.Nombre = source.Nombre;
            target.Descripcion = source.Descripcion;
        }
    }
}