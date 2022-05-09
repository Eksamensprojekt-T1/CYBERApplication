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
        // Creating connectionstring to DB
        static private string ConnectionString = Properties.Settings.Default.WPF_Connection;

        // Defining the ViewModel lists
        public ObservableCollection<Question> QuestionVM { get; set; } = new ObservableCollection<Question>();
        public ObservableCollection<MultipleChoice> MultipleChoiceVM { get; set; } = new ObservableCollection<MultipleChoice>();
        public ObservableCollection<Category> CategoryVM = new ObservableCollection<Category>();

        // Defining repository objects
        QuestionRepository QuestionRepo = new QuestionRepository(ConnectionString);
        MultipleChoiceRepository MultipleChoiceRepo = new MultipleChoiceRepository(ConnectionString);
        CategoryRepository CategoryRepo = new CategoryRepository(ConnectionString);

        public MultipleChoiceCreatorViewModel()
        {
            foreach (Question question in QuestionRepo.GetAll())
            {
                QuestionVM.Add(question);
            }
            foreach (MultipleChoice multipleChoice in MultipleChoiceRepo.GetAll())
            {
                MultipleChoiceVM.Add(multipleChoice);
            }
            foreach (Category category in CategoryRepo.GetAll())
            {
                CategoryVM.Add(category);
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

        public void AddMultipleChoice(string mCName, DateTime dateOfCreation)
        {

            MultipleChoice newMultipleChoice = new(mCName, dateOfCreation);

            // Add Object to Repository and gets ID
            newMultipleChoice.MCID = MultipleChoiceRepo.Add(newMultipleChoice);

            // Add object to ViewModel List
            MultipleChoiceVM.Add(newMultipleChoice);
        }
    }
}
