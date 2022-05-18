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
    /// Interaction logic for QuestionAnswerPage.xaml
    /// </summary>
    public partial class QuestionAnswerPage : Page
    {
        QuestionAnswerViewModel qvm = new QuestionAnswerViewModel();

        public QuestionAnswerPage()
        {
            InitializeComponent();
            FillComboBox();
            DataContext = qvm;
        }

        private void FillComboBox()
        {
            question_cb.ItemsSource = qvm.QuestionVM;
            question_cb.DisplayMemberPath = "QuestionDescription";
        }

        private void Save_And_Exit_btn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/GoodbyePage.xaml", UriKind.Relative));
        }
        private void Next_Question_btn(object sender, RoutedEventArgs e)
        {

        }
        private void Last_Question_btn(object sender, RoutedEventArgs e)
        {

        }
    }
}
