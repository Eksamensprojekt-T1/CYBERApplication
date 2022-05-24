using AdminApplication.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AdminApplication.Views
{
    /// <summary>
    /// Interaction logic for OverviewPage.xaml
    /// </summary>
    public partial class OverviewPage : Page
    {

        OverviewViewModel ovm = new OverviewViewModel();

        public OverviewPage()
        {
            InitializeComponent();
            DataContext = ovm;
        }

        private void Question_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/QuestionOverviewPage.xaml", UriKind.Relative));
        }

        private void MultipleChoice_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/MultipleChoiceOverviewPage.xaml", UriKind.Relative));
        }
    }
}
