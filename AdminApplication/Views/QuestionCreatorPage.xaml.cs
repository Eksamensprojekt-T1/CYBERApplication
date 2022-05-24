using AdminApplication.ViewModels;
using BuinsnessLogic.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace AdminApplication.Views
{
    /// <summary>
    /// Interaction logic for QuestionCreatorPage.xaml
    /// </summary>
    public partial class QuestionCreatorPage : Page
    {
        QuestionViewModel qvm = new QuestionViewModel();

        ObservableCollection<Answer> answerList = new ObservableCollection<Answer>();

        public QuestionCreatorPage()
        {
            InitializeComponent();
            FillCategory();
            DataContext = qvm;
            AnswerList_dg.ItemsSource = answerList;
        }

        private void FillCategory()
        {
            Category_cb.ItemsSource = qvm.CategoryVM;
            Category_cb.DisplayMemberPath = "CategoryName";  
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
                Uri newPicture = new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute);
                Picture_pt.Source = new BitmapImage(newPicture);
            }
        }

        private void Accept_btn_Click(object sender, RoutedEventArgs e)
        {
            string questionDescription = Title_tb.Text;
            string difficulty = Difficulty_cb.Text;
            string category = Category_cb.Text;

            qvm.AddNewQuestion(questionDescription, difficulty, category, new List<Answer>(answerList));

            NavigationService.Navigate(new Uri("Views/QuestionOverviewPage.xaml", UriKind.Relative));
            MessageBox.Show("Spørgsmål oprettet!", "Meddelelse", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CreateCategory_btn_Click(object sender, RoutedEventArgs e)
        {
            string categoryName = Category_tb.Text;
            qvm.AddCategory(categoryName);
            Category_tb.Clear();
        }

        private void CreateAnswer_btn_Click(object sender, RoutedEventArgs e)
        {
            string ansewerDescription = Answer_tb.Text;
            bool isCorrect = (bool)IsCorrect_cb.IsChecked;

            answerList.Add(new Answer(ansewerDescription, isCorrect));

            Answer_tb.Text = "";
            IsCorrect_cb.IsChecked = false;

        }

        private void Remove_btn_Click(object sender, RoutedEventArgs e)
        {
            answerList.Remove((Answer)AnswerList_dg.SelectedItem);
        }
    }
}
