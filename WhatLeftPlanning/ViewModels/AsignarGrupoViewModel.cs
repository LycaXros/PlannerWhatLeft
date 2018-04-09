using DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WhatLeftPlanning.Services;
using WhatLeftPlanning.SimpleItems;
using WhatLeftPlanning.Startup;

namespace WhatLeftPlanning.ViewModels
{
    public class AsignarGrupoViewModel : ViewModelBase
    {
        private ObservableCollection<Grupo> _grupos;
        private int _selectedGrupoId;
        private List<System.Object> _selectedUsers;
        private IUnidadTrabajo _unidadTrabajo;

        private ObservableCollection<LookUpUser> _usuarios;

        public AsignarGrupoViewModel()
        {

        }
        public AsignarGrupoViewModel(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        public event Action Done = delegate { };

        private bool CanSave()
        {
            return SelectedUsers == null ? false : SelectedUsers.Count > 0;
        }

        private async void OnSave()
        {
            var grupo = await _unidadTrabajo.Grupos.GetByID(SelectedGrupoID);
            foreach (var item in SelectedUsers)
            {
                int id = 0;
                if (int.TryParse(item.ToString(), out id))
                {
                    var usuario = await _unidadTrabajo.Usuarios.GetByID(id);
                    await _unidadTrabajo.Grupos.AsignarUsuario(usuario, grupo);
                }
            }
            LoadUsers(SelectedGrupoID);
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
                .Where(x => !x.ID.Equals(DatosEstaticos.CurrentUser.ID) &&
                            !users.Contains(x)).ToList();

            Usuarios = new ObservableCollection<LookUpUser>(ToLookUpUser(users));
        }

        public ObservableCollection<Grupo> Grupos
        {
            get => _grupos; private set
            {
                SetProperty(ref _grupos, value);
            }
        }

        public RelayCommand SaveCommand { get; }
        public int SelectedGrupoID
        {
            get => _selectedGrupoId; set
            {
                SetProperty(ref _selectedGrupoId, value);
                LoadUsers(_selectedGrupoId);
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

        public ObservableCollection<LookUpUser> Usuarios
        {
            get => _usuarios;
            private set => SetProperty(ref _usuarios, value);
        }
    }
}