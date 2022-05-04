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

namespace ScreeningApplication.Views
{
    /// <summary>
    /// Interaction logic for ParticipantWelcomePage.xaml
    /// </summary>
    public partial class ParticipantWelcomePage : Page
    {
        public ParticipantWelcomePage()
        {
            InitializeComponent();
        }

        private void Continue_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/ParticipantInsertInfoPage.xaml", UriKind.Relative));

        }

        private void ClearContent(object sender, MouseButtonEventArgs e)
        {
            ScreeningPassword_tb.Clear();
        }
    }
}
