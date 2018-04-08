using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;


namespace WhatLeftPlanning.Views
{
    /// <summary>
    /// Interaction logic for ReportWindows.xaml
    /// </summary>
    public partial class ReportWindows : ThemedWindow
    {
        public ReportWindows()
        {
            InitializeComponent();
        }

        private void LoadedWin(object sender, RoutedEventArgs e)
        {
            TareaUsuarioReport report = new TareaUsuarioReport();
            DocumentPresenter.DocumentSource = report;
            report.CreateDocument();
        }
    }
}
