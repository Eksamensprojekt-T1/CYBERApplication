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
        public ObservableCollection<Category> CategoryVM = new ObservableCollection<Category>();

        // Defining repository objects
        QuestionRepository QuestionRepo = new QuestionRepository("Server=10.56.8.36;Database=PEDB01;User Id=PE-01;Password=OPENDB_01;");
        CategoryRepository CategoryRepo = new CategoryRepository("Server=10.56.8.36;Database=PEDB01;User Id=PE-01;Password=OPENDB_01;");

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

        }
        
        public void AddNewQuestion(string questionDescription, string categoryName, string difficulty)
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


            Category targetCategory = null;

            foreach (Category category in CategoryRepo.GetAll())
            {
                if (category.CategoryName == categoryName)
                {
                    targetCategory = category;
                    break;
                }
                return;
            }

            Question newQuestion = new(questionDescription, difficultyChosen);

            // Add Object to Repository and gets ID
            newQuestion.QuestionID = QuestionRepo.Add(newQuestion);

            // Add object to ViewModel List
            newQuestion.QuestionCategory = targetCategory;
            QuestionVM.Add(newQuestion);

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
            return CategoryVM;
        }

        public void AddPicture(string pictureName, string picturePath)
        {

        }

        public void AddCategory(string categoryName)
        {
            Category newCategory = new Category(categoryName); 

            //Add to Repo and gets ID
            newCategory.CategoryID = CategoryRepo.Add(newCategory);

            // Add object to ViewModel List
            CategoryVM.Add(newCategory);
        }

    }
}
