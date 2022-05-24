using AdminApplication.ViewModels;
using BuinsnessLogic.Models;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace AdminApplication.Views
{
    /// <summary>
    /// Interaction logic for QuestionUpdaterPage.xaml
    /// </summary>
    public partial class QuestionUpdaterPage : Page
    {
        public QuestionUpdaterPage()
        {
            InitializeComponent();
            //NavigationService.LoadCompleted += NavigationService_LoadCompleted;
            FillCategory();
            DataContext = quvm;
            AnswerList_dg.ItemsSource = answerList;
        }

        QuestionUpdaterViewModel quvm = new QuestionUpdaterViewModel();

        ObservableCollection<Answer> answerList = new ObservableCollection<Answer>();

        private void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            //int questionID = (int)e.ExtraData;

            //Do something
        }

        private void FillCategory()
        {
            Category_cb.ItemsSource = quvm.CategoryVM;
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

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            //skal rettet//

            NavigationService.Navigate(new Uri("Views/QuestionOverviewPage.xaml", UriKind.Relative));
            MessageBox.Show("Spørgsmål oprettet!", "Meddelelse", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CreateCategory_btn_Click(object sender, RoutedEventArgs e)
        {
            string categoryName = Category_tb.Text;
            quvm.AddCategory(categoryName);
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
