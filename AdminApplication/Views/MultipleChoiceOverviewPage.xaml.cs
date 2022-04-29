﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdminApplication.Views
{
    /// <summary>
    /// Interaction logic for MultipleChoiceOverviewPage.xaml
    /// </summary>
    public partial class MultipleChoiceOverviewPage : Page
    {
        public MultipleChoiceOverviewPage()
        {
            InitializeComponent();
        }

        private void MainMenu_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/OverviewPage.xaml", UriKind.Relative));
        }

        private void Create_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/MultipleChoiceCreatorPage.xaml", UriKind.Relative));
        }
    }
}