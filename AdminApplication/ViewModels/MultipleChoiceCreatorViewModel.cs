using BuinsnessLogic.Models;
using BuinsnessLogic.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.ViewModels
{
    public class MultipleChoiceCreatorViewModel
    {
        static private string CnnStr = Properties.Settings.Default.WPF_Connection;

        // Defining the ViewModel lists
        public ObservableCollection<Question> QuestionVM { get; set; } = new ObservableCollection<Question>();

        // Defining repository objects
        QuestionRepository QuestionRepo = new QuestionRepository(CnnStr);

        public MultipleChoiceCreatorViewModel()
        {
            foreach (Question question in QuestionRepo.GetAll())
            {
                QuestionVM.Add(question);
            }
        }

        public ObservableCollection<Question> GetAllQuestions()
        {
            return QuestionVM;
        }

        public void AddQuestion()
        {

        }

        public void RemoveQuestion()
        {

        }

        public void AddMultipleChoice()
        {

        }
    }
}
