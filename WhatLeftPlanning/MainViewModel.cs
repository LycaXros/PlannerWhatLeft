using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WhatLeftPlanning.Startup;
using DevExpress.Xpf.Ribbon;

namespace WhatLeftPlanning
{
    public class MainViewModel : NavigationViewModelBase
    {
        public RibbonControl RibbonControlBar { get; }

        public object HamburgerMenuSelectedItem
        {
            get { return GetProperty(() => HamburgerMenuSelectedItem); }
            set { SetProperty(() => HamburgerMenuSelectedItem, value); }
        }

        public MainViewModel()
        {
            //    HamburgerMenuItems = new ReadOnlyCollection<IHamburgerMenuItemViewModel>(InitializeMenuItems());
            //    HamburgerMenuBottomBarItems = new ReadOnlyCollection<IHamburgerMenuBottomBarItemViewModel>(InitializeBottomBarItems());
            RibbonControlBar = new RibbonControl();
            InitializeRibbonControlItems();
            
        }

        private void InitializeRibbonControlItems()
        {
        }

        protected virtual IList<IHamburgerMenuItemViewModel> InitializeMenuItems()
        {

            var user = DatosEstaticos.CurrentUser;

            List<string> roles = new List<string>();
            foreach (var item in user.Roles)
            {
                roles.Add(item.Nombre);
            }

            
            var result = new List<IHamburgerMenuItemViewModel>();

            result.Add(new NavigationItemModel("Home") { NavigationTarget = typeof(Home), Glyph = "Icons/Home.png" });

            if (roles.Contains(nameof(DataEntity.DataTransform.RolConstantes.Administrador)))

            result.Add(new SeparatorItem());
            var subMenu = new SubMenuItemModel("Menu") { Glyph = "Icons/Menu.png" };
            subMenu.Items.Add(new SubMenuNavigationItemModel("Reportes", "Ver Reportes") { RightContent = "RC", ShowInPreview = true, SelectOnClick = false });
            subMenu.Items.Add(new SubMenuNavigationItemModel("Otro", "PreviewItem 2") { ShowInPreview = true , NavigationTarget = typeof(Home)});
            subMenu.Items.Add(new SubMenuNavigationItemModel("MenuSubItem 3", null) { IsSelected = true });
            subMenu.Items.Add(new SubMenuNavigationItemModel("MenuSubItem 4", null) { RightContent = "RC", ShowMark = true });
            result.Add(subMenu);
            //result.Add(new HyperlinkItemModel("More information...", new Uri("https://www.devexpress.com/")) { IsAlternatePlacementItem = true, });
            result.Add(new NavigationItemModel("About") { NavigationTarget = typeof(About), IsAlternatePlacementItem = true, Glyph = "Icons/About.png" });
            return result;
        }
        protected virtual IList<IHamburgerMenuBottomBarItemViewModel> InitializeBottomBarItems()
        {
            return new List<IHamburgerMenuBottomBarItemViewModel>() {
                new BottomBarNavigationItemModel() { NavigationTarget = typeof(Settings), Glyph = "Icons/Settings.png", IsAlternatePlacementItem = true },
                new BottomBarCheckableItemModel() { Glyph = "Icons/Check.png" },
                new BottomBarRadioItemModel("RadioGroup") { Glyph = "Icons/Radio1.png" },
                new BottomBarRadioItemModel("RadioGroup") { Glyph = "Icons/Radio2.png" }
            };
        }
    }
}
