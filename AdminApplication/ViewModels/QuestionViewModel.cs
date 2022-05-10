using BuinsnessLogic.Models;
using BuinsnessLogic.Persistence;
using System.Collections.ObjectModel;

namespace AdminApplication.ViewModels
{
    public class QuestionViewModel
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


        //=========================================================================
        // Constructor
        //=========================================================================

        public QuestionViewModel()
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
        // AddNewQuestion (CRUD: Create)
        //=========================================================================

        public void AddNewQuestion(string questionDescription, string difficulty, string categoryName, string answer)
        {
            Level difficultyChosen;

            switch (difficulty)
            {
                case "Nem":
                    difficultyChosen = Level.Nem;
                    break;
                case "Moderat":
                    difficultyChosen = Level.Moderat;
                    break;
                case "Svær":
                    difficultyChosen = Level.Svær;
                    break;
                default:
                    difficultyChosen = Level.Nem;
                    break;
            }

            Category? categoryChosen = null;
            foreach (Category category in CategoryVM)
            {
                if (category.CategoryName == categoryName)
                {
                    categoryChosen = category;
                    break;
                }
            }

            Question newQuestion = new(questionDescription, difficultyChosen, categoryChosen);
            newQuestion.QuestionID = QuestionRepo.Add(newQuestion);
            QuestionVM.Add(newQuestion);
        }

        //=========================================================================
        // DeleteQuestion (CRUD: Delete)
        //=========================================================================
        public void DeleteQuestion(object selectedItem)
        {
            Question question = (Question)selectedItem;

            for (int i = 0; i < QuestionVM.Count; i++)
            {
                if (question.QuestionID == QuestionVM[i].QuestionID)
                {
                    QuestionRepo.Delete(QuestionVM[i].QuestionID);
                    QuestionVM.Remove(QuestionVM[i]);
                }
            }
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
