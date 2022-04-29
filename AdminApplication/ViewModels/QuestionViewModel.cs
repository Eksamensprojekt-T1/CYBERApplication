using BuinsnessLogic.Models;
using BuinsnessLogic.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.ViewModels
{
    public class QuestionViewModel
    {
        // Defining the ViewModel lists
        List<Question> questionList = new List<Question>();
        List<MainCategory> mainCategoryList = new List<MainCategory>();
        List<SubCategory> subCategoryList = new List<SubCategory>();

        // Defining repository objects
        QuestionRepository QuestionRepo = new QuestionRepository("Server=10.56.8.36;Database=PEDB01;User Id=PE-01;Password=OPENDB_01;");

        public void AddNewQuestion(string questionDescription, Level difficulty)
        {
            // Add object to ViewModel List
            questionList.Add(new Question(questionDescription, difficulty));

            // Add Object to Repository
            QuestionRepo.Add(new Question(questionDescription, difficulty));
        }

        public void AddAnswer(string answerDescription, bool isItCorrect)
        {

        }

        public List<Question> GetAllQuestions()
        {
            return questionList;
        }

        public List<MainCategory> GetAllMainCategories()
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
