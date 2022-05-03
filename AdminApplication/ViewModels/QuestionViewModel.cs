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
        ObservableCollection<Category> CategoryList = new ObservableCollection<Category>();

        // Defining repository objects
        QuestionRepository QuestionRepo = new QuestionRepository("Server=10.56.8.36;Database=PEDB01;User Id=PE-01;Password=OPENDB_01;");

        public QuestionViewModel()
        {
            foreach (Question question in QuestionRepo.GetAll())
            {
                QuestionVM.Add(question);
            }
        }
        
        public void AddNewQuestion(string questionDescription, string difficulty)
        {

            // Difficulty
            Level difficultyChosen = Level.easy;

            switch (difficulty)
            {
                case "Nem":
                    difficultyChosen = Level.easy;
                    break;
                case "Moderat":
                    difficultyChosen = Level.moderate;
                    break;
                case "Svær":
                    difficultyChosen = Level.hard;
                    break;
            }

            // Add object to ViewModel List
            QuestionVM.Add(new Question(questionDescription, difficultyChosen));

            // Add Object to Repository
            QuestionRepo.Add(new Question(questionDescription, difficultyChosen));
        }

        public void AddAnswer(string answerDescription, bool isItCorrect)
        {

        }

        public ObservableCollection<Question> GetAllQuestions()
        {
            return QuestionVM;
        }

        public ObservableCollection<Category> GetAllCategories()
        {
            return CategoryList;
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
