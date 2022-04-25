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
    /// Interaction logic for MultipleChoiceCreatorPage.xaml
    /// </summary>
    public partial class MultipleChoiceCreatorPage : Page
    {
        public MultipleChoiceCreatorPage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/MultipleChoiceOverviewPage.xaml", UriKind.Relative));
        }

        private void ViewQuestion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
