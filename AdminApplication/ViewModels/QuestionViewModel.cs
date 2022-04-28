using BuinsnessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.ViewModels
{
    public class QuestionViewModel
    {
        List<Question> QuestionList = new List<Question>();

        List<Maincategory> MaincategoryList = new List<Maincategory>();

        List<Subcategory> SubcategoryList = new List<Subcategory>();

        List<Question> GetAllQuestions = new List<Question>();

        List<Question> GetAllMaincategories = new List<Question>();

        public void AddNewQuestion(string questionName, string description, Level difficulty)
        {
            
        }

        public void AddAnswer(string answerDescription, bool isItCorrect)
        {

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
