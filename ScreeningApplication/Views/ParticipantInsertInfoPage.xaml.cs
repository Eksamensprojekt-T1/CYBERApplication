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
    /// Interaction logic for ParticipantInsertInfoPage.xaml
    /// </summary>
    public partial class ParticipantInsertInfoPage : Page
    {
        public ParticipantInsertInfoPage()
        {
            InitializeComponent();
        }

        private void Start_Screening_btn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/QuestionAnswerPage.xaml", UriKind.Relative));
        }

        private void ClearName(object sender, MouseButtonEventArgs e)
        {
            Name_tb.Clear();
        }
        private void ClearDOB(object sender, MouseButtonEventArgs e)
        {
            DOB_tb.Clear();
        }
        private void ClearGender(object sender, MouseButtonEventArgs e)
        {
            Gender_tb.Clear();
        }
        private void ClearEducation(object sender, MouseButtonEventArgs e)
        {
            Education_tb.Clear();
        }
    }
}
