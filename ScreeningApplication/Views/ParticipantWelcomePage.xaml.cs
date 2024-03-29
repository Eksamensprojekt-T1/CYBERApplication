﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ScreeningApplication.ViewModels;

namespace ScreeningApplication.Views
{
    /// <summary>
    /// Interaction logic for ParticipantWelcomePage.xaml
    /// </summary>
    public partial class ParticipantWelcomePage : Page
    {
        WelcomeViewModel participantWelcomeVM;

        public ParticipantWelcomePage()
        {
            InitializeComponent();
            participantWelcomeVM = new();
            DataContext = participantWelcomeVM;
            Continue_btn.IsEnabled = false;
        }

        private void Continue_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/ParticipantInsertInfoPage.xaml", UriKind.Relative));
        }

        private void ScreeningPassword_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Hides button until a correct screening password is entered in the textbox and exists.
            if (int.TryParse(ScreeningPassword_tb.Text, out int screeningPassword)) 
            {
                Continue_btn.IsEnabled = participantWelcomeVM.ScreeningExistsWithPassword(screeningPassword);
            }
            else if (ScreeningPassword_tb.Text == "test")
            {
                Continue_btn.IsEnabled = true;
            }

        }
    }
}
