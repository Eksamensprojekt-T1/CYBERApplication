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
        int currentQuestionIndex = 0;

        public QuestionAnswerPage()
        {
            InitializeComponent();
            FillQuestionComboBox();
            setupQuestion(currentQuestionIndex);
            DataContext = qvm;
        }

        private void FillQuestionComboBox()
        {
            question_cb.ItemsSource = qvm.QuestionVM;
            question_cb.DisplayMemberPath = "QuestionDescription";
        }

        private void setupQuestion(int questionNumber)
        {
            question_description_lb.Content = qvm.QuestionVM[questionNumber].QuestionDescription;
            FillAnswerListBox(questionNumber);
        }

        private void FillAnswerListBox(int questionNumber)
        {
            Answers_lb.ItemsSource = qvm.getAnswersForQuestion(qvm.QuestionVM[questionNumber]);
        }

        private void Save_And_Exit_btn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/GoodbyePage.xaml", UriKind.Relative));
        }
        private void Next_Question_btn(object sender, RoutedEventArgs e)
        {
            int nextQuestionIndex = currentQuestionIndex + 1;
            if (nextQuestionIndex > 0 && nextQuestionIndex < qvm.QuestionVM.Count)
            {
                currentQuestionIndex++;
            }
            else currentQuestionIndex = qvm.QuestionVM.Count - 1;

            setupQuestion(currentQuestionIndex);
        }
        private void Last_Question_btn(object sender, RoutedEventArgs e)
        {
            int lastQuestionIndex = currentQuestionIndex - 1;
            if (lastQuestionIndex > 0 && lastQuestionIndex < qvm.QuestionVM.Count)
            {
                currentQuestionIndex--;
            }
            else currentQuestionIndex = 0;

            setupQuestion(currentQuestionIndex);
        }
    }
}
