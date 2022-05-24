using AdminApplication.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AdminApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Frame.Source = new Uri("OverviewPage.xaml", UriKind.Relative);
        }
    }
}
