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
    public class QuestionUpdaterViewModel
    {

        //=========================================================================
        // Fields & Properties
        //=========================================================================

        // Connection string
        static private string connectionString = Properties.Settings.Default.WPF_Connection;

        // Observablecollections
        public ObservableCollection<Question> QuestionVM { get; set; } = new ObservableCollection<Question>();
        public ObservableCollection<Category> CategoryVM = new ObservableCollection<Category>();
        public ObservableCollection<Answer> AnswerVM { get; set; } = new ObservableCollection<Answer>();
        public ObservableCollection<Picture> PictureVM { get; set; } = new ObservableCollection<Picture>();

        // Repositories
        QuestionRepository QuestionRepo = new QuestionRepository(connectionString);
        CategoryRepository CategoryRepo = new CategoryRepository(connectionString);
        AnswerRepository AnswerRepo = new AnswerRepository(connectionString);

        public QuestionUpdaterViewModel()
        {
            foreach (Question question in QuestionRepo.GetAll())
            {
                QuestionVM.Add(question);
            }
            foreach (Category category in CategoryRepo.GetAll())
            {
                CategoryVM.Add(category);
            }
            foreach (Answer answer in AnswerRepo.GetAll())
            {
                AnswerVM.Add(answer);
            }
        }

        //=========================================================================
        // UpdateQuestion (CRUD: Update)
        //=========================================================================

        public void UpdateQuestion()
        {
            throw new NotImplementedException();
        }

        //=========================================================================
        // AddAnswer (CRUD: Create)
        //=========================================================================

        public void AddAnswer(string answerDescription, bool isItCorrect)
        {
            Answer newAnswer = new Answer(answerDescription, isItCorrect);
            newAnswer.AnswerID = AnswerRepo.Add(newAnswer);
            AnswerVM.Add(newAnswer);
        }

        //=========================================================================
        // AddCategory (CRUD: Create)
        //=========================================================================

        public void AddCategory(string categoryName)
        {
            Category newCategory = new Category(categoryName);

            newCategory.CategoryID = CategoryRepo.Add(newCategory);
            CategoryVM.Add(newCategory);
        }

    }
}
