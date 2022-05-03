﻿using AdminApplication.ViewModels;
using Microsoft.Win32;
using System;
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
    /// Interaction logic for QuestionCreatorPage.xaml
    /// </summary>
    public partial class QuestionCreatorPage : Page
    {
        QuestionViewModel QuestionVM = new QuestionViewModel();

        public QuestionCreatorPage()
        {
            InitializeComponent();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/QuestionOverviewPage.xaml", UriKind.Relative));
        }

        private void Picture_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Picture_tb.Text = openFileDialog.FileName;
                Uri test = new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute);
                Picture_pt.Source = new BitmapImage(test);
            }
        }

        private void Accept_btn_Click(object sender, RoutedEventArgs e)
        {

            string questionDescription = Title_tb.Text;
            string difficulty = Difficulty_cb.Text;
            int difficultyChosen = 0;

            switch (difficulty)
            {
                case "Nem":
                    difficultyChosen = 0;
                    break;
                case "Moderat":
                    difficultyChosen = 1;
                    break;
                case "Svær":
                    difficultyChosen = 2;
                    break;
                default:
                    break;
            }

            QuestionVM.AddNewQuestion(questionDescription, (BuinsnessLogic.Models.Level)difficultyChosen);
            MessageBox.Show("Spørgsmål oprettet!", "Meddelelse", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CreateCategory_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
