using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataEntity.Model;
using DevExpress.Mvvm;
using WhatLeftPlanning.Services;
using WhatLeftPlanning.SimpleItems;
using WhatLeftPlanning.Startup;

namespace WhatLeftPlanning.ViewModels
{
    public class ManejoUsuariosViewModel : ViewModelBase, ISupportServices
    {
        private IUnidadTrabajo _unidadTrabajo;
        private ObservableCollection<SimpleUsuario> _usuarios;
        private IServiceContainer _serviceContainer;
        private bool editMode;
        private SimpleUsuario _editingUser;
        private int _rolID;

        public RelayCommand<SimpleUsuario> EditarUsuarioCommand { get; }
        public RelayCommand<SimpleUsuario> EliminarCommand { get; }
        public RelayCommand CancelCommand { get; }
        public RelayCommand NuevoUserCommand { get; }
        public RelayCommand SaveCommand { get; }
        public ObservableCollection<SimpleUsuario> Usuarios { get => _usuarios; set => SetProperty(ref _usuarios, value); }

        public event Action Done = delegate { };

        protected virtual IMessageBoxService MessageBoxService => ServiceContainer.GetService<IMessageBoxService>();

        public ManejoUsuariosViewModel()
        {

        }
        public ManejoUsuariosViewModel(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
            SetEditing(false, new SimpleUsuario());

            EditarUsuarioCommand = new RelayCommand<SimpleUsuario>(OnEdit);
            EliminarCommand = new RelayCommand<SimpleUsuario>(OnDel);
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
            NuevoUserCommand = new RelayCommand(OnNewUser);

        }

        private void EditingUser_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void OnNewUser()
        {
            SetEditing(false, new SimpleUsuario());
        }

        private void SetEditing(bool editing, SimpleUsuario user = null)
        {
            if (EditingUser != null) EditingUser.ErrorsChanged -= EditingUser_ErrorsChanged;
            EditingUser = user;
            EditMode = editing;
            EditingUser.ErrorsChanged += EditingUser_ErrorsChanged;
        }

        private async void OnSave()
        {
            var usuario = new Usuario();
            if (EditMode) usuario = await _unidadTrabajo.Usuarios.GetByID(EditingUser.ID);
            await GetUsuarioTrasnform(usuario);

            if(!EditMode) _unidadTrabajo.Usuarios.Add(usuario);

            OnNewUser();
            Done();
        }

        private async Task GetUsuarioTrasnform(Usuario target)
        {
            target.Nick = EditingUser.Nick;
            target.Nombre = EditingUser.Nombre;
            target.Apellido = EditingUser.Apellido;
            target.Contraseña = DataEntity.DataTransform.Encriptador.Encriptar(EditingUser.ConfirmContraseña);

            var roles = target.Roles.ToList();

            if (roles.Count > 0)
            {
                foreach (var item in roles)
                    target.Roles.Remove(item);
                await _unidadTrabajo.Complete();
            }


            var rolesList = TiposRoles.ToList();
            target.Roles = new List<Rol>();
            if (RolID == 1)
            {
                foreach (var item in rolesList)
                {
                    target.Roles.Add(item);
                }
            }
            else if (RolID == 2)
            {
                foreach (var item in rolesList)
                {
                    if (item.ID != 1)
                        target.Roles.Add(item);
                }
            }
            else if (RolID == 3)
                target.Roles.Add(rolesList.First(x => x.ID == 3));

        }

        private bool CanSave()
        {
            return !EditingUser.HasErrors;
        }

        private void OnCancel()
        {
            OnNewUser();
            Done();
        }

        private async void OnDel(SimpleUsuario obj)
        {
            var r = MessageBoxService.ShowMessage("Desea Borrar Esta Usuario?", "Eliminado", MessageButton.YesNo);
            if (r == MessageResult.Yes)
            {
                await Task.Run(() => Thread.Sleep(100));
                var user = await _unidadTrabajo.Usuarios.GetByID(obj.ID);
                if (user != null)
                    _unidadTrabajo.Usuarios.Remove(user);

                await _unidadTrabajo.Complete();
                LoadUser();
            }
        }

        private void OnEdit(SimpleUsuario obj)
        {
            SetEditing(true, obj);
        }

        public async void LoadUser()
        {
            var usuarios = await _unidadTrabajo.Usuarios.GetAll();
            usuarios = usuarios.Where(x => !x.ID.Equals(DatosEstaticos.CurrentUser.ID)).ToList();

            IEnumerable<SimpleUsuario> lista = TransformarASimpleUsuarioLista(usuarios);
            Usuarios = new ObservableCollection<SimpleUsuario>(lista);
        }

        private IEnumerable<SimpleUsuario> TransformarASimpleUsuarioLista(IEnumerable<Usuario> usuarios)
        {
            List<SimpleUsuario> lista = new List<SimpleUsuario>();

            foreach (var item in usuarios)
            {
                lista.Add(new SimpleUsuario
                {
                    ID = item.ID,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Contraseña = DataEntity.DataTransform.Encriptador.Desencriptar(item.Contraseña),
                    Nick = item.Nick,
                    Roles = item.Roles.ToList()
                });
            }

            return lista.AsEnumerable();
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

        public SimpleUsuario EditingUser
        {
            get => _editingUser;
            set => SetProperty(ref _editingUser, value);
        }

        public bool EditMode
        {
            get => editMode;
            set
            {
                SetProperty(ref editMode, value);
            }
        }
        public IEnumerable<Rol> TiposRoles
        {
            get
            {
                return _unidadTrabajo.GetContext().Rol.ToList();
            }
        }
        public int RolID { get => _rolID; set => SetProperty(ref _rolID, value); }
        //public bool EditMode
        //{
        //    get { return editMode; }
        //    set { SetProperty(ref editMode, value); }
        //}
    }
}