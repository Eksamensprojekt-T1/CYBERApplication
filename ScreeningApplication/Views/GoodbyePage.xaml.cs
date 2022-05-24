using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ScreeningApplication.Views
{
    /// <summary>
    /// Interaction logic for GoodbyePage.xaml
    /// </summary>
    public partial class GoodbyePage : Page
    {
        public GoodbyePage()
        {
            InitializeComponent();
        }

        private void Continue_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/ParticipantWelcomePage.xaml", UriKind.Relative));
        }
    }
}
