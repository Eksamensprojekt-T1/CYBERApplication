using ScreeningApplication.ViewModels;
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
        InfoViewModel participantWM;
        public ParticipantInsertInfoPage()
        {
            InitializeComponent();
            participantWM = new();
        }

        private void Start_Screening_btn(object sender, RoutedEventArgs e)
        {
            string name = Name_tb.Text.Length == 0 ? Name_tb.Text : "";
            DateTime dob = DOB_dp.DisplayDate;
            string gender = Gender_tb.Text.Length == 0 ? Gender_tb.Text : "";
            string education = Education_tb.Text.Length == 0 ? Education_tb.Text : "";
            string motivation = Motivation_tb.Text.Length == 0 ? Motivation_tb.Text : "";
            participantWM.StartScreening(name, dob, gender, education, motivation);
            NavigationService.Navigate(new Uri("Views/QuestionAnswerPage.xaml", UriKind.Relative));
        }

        private void ClearName(object sender, MouseButtonEventArgs e)
        {
            Name_tb.Clear();
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
