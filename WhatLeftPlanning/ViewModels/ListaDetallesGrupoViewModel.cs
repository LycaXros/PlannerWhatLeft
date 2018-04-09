using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DataEntity.Model;
using DevExpress.Mvvm;
using WhatLeftPlanning.Services;
using WhatLeftPlanning.SimpleItems;

namespace WhatLeftPlanning.ViewModels
{
    public class ListaDetallesGrupoViewModel : ViewModelBase, ISupportServices
    {
        private IUnidadTrabajo _unidadTrabajo;

        public RelayCommand EliminarCommand { get; }

        private IServiceContainer _serviceContainer;
        private ObservableCollection<LookUpGrupo> _grupos;
        private LookUpGrupo _selectedItem;

        public event Action Done = delegate { };

        protected virtual IMessageBoxService MessageBoxService => ServiceContainer.GetService<IMessageBoxService>();

        public ListaDetallesGrupoViewModel()
        {

        }
        public ListaDetallesGrupoViewModel(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;

            EliminarCommand = new RelayCommand(OnDelete, CanDoChanges);
        }

        private async void OnDelete()
        {
            var r = MessageBoxService.ShowMessage("Desea Borrar Este Grupo?", "Eliminado", MessageButton.YesNo);
            if (r == MessageResult.Yes)
            {
                var selected = await _unidadTrabajo.Grupos.GetByID(SelectedItem.Id);
                _unidadTrabajo.Grupos.Remove(selected);
                await _unidadTrabajo.Complete();
                LoadGrupos();
            }
        }

        private bool CanDoChanges()
        {
            return SelectedItem != null;
        }

        public LookUpGrupo SelectedItem
        {
            get => _selectedItem; set
            {
                SetProperty(ref _selectedItem, value);
                EliminarCommand.RaiseCanExecuteChanged();
            }
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

        public ObservableCollection<LookUpGrupo> Grupos { get => _grupos; private set => SetProperty(ref _grupos, value); }

        public async void LoadGrupos()
        {

            var listaGrupos = (await _unidadTrabajo.Grupos.GetAll()).ToList();
            var lookUpItems = await GruposToLookUpList(listaGrupos);
            Grupos = new ObservableCollection<LookUpGrupo>(lookUpItems);
        }

        private async Task<List<LookUpGrupo>> GruposToLookUpList(List<Grupo> listaGrupos)
        {
            List<LookUpGrupo> lookUps = new List<LookUpGrupo>();
            foreach (var item in listaGrupos)
            {
                lookUps.Add(new LookUpGrupo()
                {
                    Id = item.ID,
                    Nombre = item.Nombre,
                    Total = await _unidadTrabajo.Grupos.UsuariosPorGrupo(item),
                    Descripcion = item.Descripcion
                });
            }

            return lookUps;
        }
    }
}