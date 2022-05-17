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

        //=========================================================================
        // Fields & Properties
        //=========================================================================

        // Connection string
        static private string ConnectionString = Properties.Settings.Default.WPF_Connection;

        // Observablecollections
        public ObservableCollection<Question> QuestionVM { get; set; } = new ObservableCollection<Question>();
        public ObservableCollection<MultipleChoice> MultipleChoiceVM { get; set; } = new ObservableCollection<MultipleChoice>();
        // Repositories
        QuestionRepository QuestionRepo = new QuestionRepository(ConnectionString);
        MultipleChoiceRepository MultipleChoiceRepo = new MultipleChoiceRepository(ConnectionString);
        //=========================================================================
        // Constructors
        //=========================================================================

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
        }

        //=========================================================================
        // AddQuestion (CRUD: Create)
        // Adds a question to a multiple choice
        //=========================================================================

        public void AddQuestion()
        {

        }

        //=========================================================================
        // RemoveQuestion (CRUD: Delete)
        // Removes a question from a multiple choice
        //=========================================================================

        public void RemoveQuestion()
        {

        }

        //=========================================================================
        // AddMultipleChoice (CRUD: Create)
        //=========================================================================

        public void AddMultipleChoice(string multipleChoiceName, DateTime dateOfCreation)
        {
            MultipleChoice newMultipleChoice = new(multipleChoiceName, dateOfCreation);
            
            // Adds multiple choice to repository (database)
            newMultipleChoice.MCID = MultipleChoiceRepo.Add(newMultipleChoice);

            // Adds multiple choice to ViewModel observableList
            MultipleChoiceVM.Add(newMultipleChoice);
        }

    }
}
