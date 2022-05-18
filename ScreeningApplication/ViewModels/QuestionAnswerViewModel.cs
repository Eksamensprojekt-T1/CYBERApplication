using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuinsnessLogic.Models;
using BuinsnessLogic.Persistence;
using System.Collections.ObjectModel;

namespace ScreeningApplication.ViewModels
{
    public class QuestionAnswerViewModel
    {
        //=========================================================================
        // Fields & Properties
        //=========================================================================

        // Connection string
        static private string connectionString = Properties.Settings.Default.WPF_Connection;

        // Observablecollections
        public ObservableCollection<Question> QuestionVM { get; set; } = new ObservableCollection<Question>();
        public ObservableCollection<Answer> AnswerVM { get; set; } = new ObservableCollection<Answer>();
        public ObservableCollection<Picture> PictureVM { get; set; } = new ObservableCollection<Picture>();

        // Repositories
        QuestionRepository QuestionRepo = new QuestionRepository(connectionString);
        AnswerRepository AnswerRepo = new AnswerRepository(connectionString);

        public QuestionAnswerViewModel()
        {
            foreach (Question question in QuestionRepo.GetAll())
            {
                QuestionVM.Add(question);
            }
            foreach (Answer answer in AnswerRepo.GetAll())
            {
                AnswerVM.Add(answer);
            }
        }

        public IEnumerable<Answer> getAnswersForQuestion(Question question)
        {
            return question.Answers;
        }
    }
}
