using AdminApplication.ViewModels;
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

        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
