using AdminApplication.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AdminApplication.Views
{
    /// <summary>
    /// Interaction logic for QuestionOverviewPage.xaml
    /// </summary>
    public partial class QuestionOverviewPage : Page
    {
        QuestionViewModel qvm = new QuestionViewModel();

        public QuestionOverviewPage()
        {
            InitializeComponent();
            DataContext = qvm;
            //string translate = qvm.GetTranslateDifficulty();
        }

        private void MainMenu_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/OverviewPage.xaml", UriKind.Relative));
        }

        private void Create_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/QuestionCreatorPage.xaml", UriKind.Relative));
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("Views/QuestionUpdaterPage.xaml?SelectedItem="+Question_dg.SelectedItem, UriKind.Relative));

            var questionID = Question_dg.SelectedItem;            
            QuestionUpdaterPage questionUpdaterPage = new QuestionUpdaterPage();
            NavigationService.Navigate(questionUpdaterPage, questionID);
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            qvm.DeleteQuestion(Question_dg.SelectedItem);
        }
    }
}
