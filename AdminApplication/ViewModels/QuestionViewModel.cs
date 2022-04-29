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
    public class QuestionViewModel
    {
        // Defining the ViewModel lists
        public ObservableCollection<Question> QuestionVM { get; set; } = new ObservableCollection<Question>();
        ObservableCollection<MainCategory> mainCategoryList = new ObservableCollection<MainCategory>();
        ObservableCollection<SubCategory> subCategoryList = new ObservableCollection<SubCategory>();

        // Defining repository objects
        QuestionRepository QuestionRepo = new QuestionRepository("Server=10.56.8.36;Database=PEDB01;User Id=PE-01;Password=OPENDB_01;");

        public QuestionViewModel()
        {
            foreach (Question question in QuestionRepo.GetAll())
            {
                QuestionVM.Add(question);
            }
        }
        
        public void AddNewQuestion(string questionDescription, Level difficulty)
        {
            // Add object to ViewModel List
            QuestionVM.Add(new Question(questionDescription, difficulty));

            // Add Object to Repository
            QuestionRepo.Add(new Question(questionDescription, difficulty));
        }

        public void AddAnswer(string answerDescription, bool isItCorrect)
        {

        }

        public ObservableCollection<Question> GetAllQuestions()
        {
            return QuestionVM;
        }

        public ObservableCollection<MainCategory> GetAllMainCategories()
        {
            return mainCategoryList;
        }

        public void AddIllustration(string fileName, string filePath)
        {

        }

        public void SelectMaincategoryName(string maincategoryName)
        {

        }

        public void SelectSubcategoryName(string subcategoryName)
        {

        }
    }
}
