using AdminApplication.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AdminApplication.Views
{
    /// <summary>
    /// Interaction logic for MultipleChoiceOverviewPage.xaml
    /// </summary>
    public partial class MultipleChoiceOverviewPage : Page
    {
        MultipleChoiceOverviewViewModel mcovm = new MultipleChoiceOverviewViewModel();
        
        public MultipleChoiceOverviewPage()
        {
            InitializeComponent();
            DataContext = mcovm;
        }

        private void MainMenu_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/OverviewPage.xaml", UriKind.Relative));
        }

        private void Create_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/MultipleChoiceCreatorPage.xaml", UriKind.Relative));
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            mcovm.DeleteMultipleChoice(MultipleChoice_dg.SelectedItem);
        }
    }
}
