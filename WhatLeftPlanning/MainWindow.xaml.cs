using Autofac;
using DevExpress.Xpf.Core;
using Unity;
using WhatLeftPlanning.Startup;

namespace WhatLeftPlanning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(Bootstrapper.Container.Resolve<Services.UnidadTrabajo>() );
        }
    }
}
