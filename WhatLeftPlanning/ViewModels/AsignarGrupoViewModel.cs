using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataEntity.Model;
using DevExpress.DataAccess.Wizard.Presenters;
using DevExpress.Mvvm;
using WhatLeftPlanning.Services;
using WhatLeftPlanning.Startup;

namespace WhatLeftPlanning.ViewModels
{
    public class AsignarGrupoViewModel : ViewModelBase
    {
        private IUnidadTrabajo _unidadTrabajo;

        public RelayCommand SaveCommand { get; }

        private ObservableCollection<Usuario> _usuarios;
        private int _selectedGrupoId;
        private ObservableCollection<Grupo> _grupos;
        private List<System.Object> _selectedUsers;

        public AsignarGrupoViewModel()
        {

        }
        public AsignarGrupoViewModel(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        private void OnSave()
        {

        }

        private bool CanSave()
        {
            return SelectedUsers == null ? false : SelectedUsers.Count > 0 ;
        }

        public ObservableCollection<Usuario> Usuarios
        {
            get => _usuarios;
            private set => SetProperty(ref _usuarios, value);
        }
        public int SelectedGrupoID
        {
            get => _selectedGrupoId; set
            {
                SetProperty(ref _selectedGrupoId, value);
                LoadUsers(_selectedGrupoId);
            }
        }

        public ObservableCollection<Grupo> Grupos
        {
            get => _grupos; private set
            {
                SetProperty(ref _grupos, value);
            }
        }
        public List<System.Object> SelectedUsers
        {
            get => _selectedUsers; set
            {
                SetProperty(ref _selectedUsers, value);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public async void LoadGrupos()
        {
            var grupos = await _unidadTrabajo.Grupos.GetAll();
            Grupos = new ObservableCollection<Grupo>(grupos);
        }

        public async void LoadUsers(int grupoId)
        {
            var users = (await _unidadTrabajo.Grupos.GetByID(grupoId))
                .UsuariosRef.ToList()
                .Select(x => x.Usuario).ToList();

            users = (await _unidadTrabajo.Usuarios.GetAll())
                .Where(x => !x.ID.Equals(DatosEstaticos.CurrentUser.ID) || 
                            !users.Contains(x) ).ToList();

            Usuarios = new ObservableCollection<Usuario>(users);
        }
    }
}