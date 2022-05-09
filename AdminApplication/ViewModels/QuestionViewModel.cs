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
        public ObservableCollection<Answer> AnswerVM { get; set; } = new ObservableCollection<Answer>();

        // Defining repository objects
        QuestionRepository QuestionRepo = new QuestionRepository("Server=10.56.8.36;Database=PEDB01;User Id=PE-01;Password=OPENDB_01;");
        CategoryRepository CategoryRepo = new CategoryRepository("Server=10.56.8.36;Database=PEDB01;User Id=PE-01;Password=OPENDB_01;");
        AnswerRepository AnswerRepo = new AnswerRepository("Server=10.56.8.36;Database=PEDB01;User Id=PE-01;Password=OPENDB_01;");
        PictureRepository PictureRepo = new PictureRepository("Server=10.56.8.36;Database=PEDB01;User Id=PE-01;Password=OPENDB_01;");

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
        public void AddNewQuestion(string questionDescription, string categoryName, string difficulty, string pictureName)
        {
            // Difficulty
            Level difficultyChosen = Level.Nem;

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
            }

            Category targetCategory = null;

            foreach (Category category in CategoryRepo.GetAll())
            {
                if (category.CategoryName == categoryName)
                {
                    targetCategory = category;
                    break;
                }
            }

            Picture targetPicture = null;

            foreach(Picture picture in PictureRepo.GetAll())
            {
                if (picture.PictureName == pictureName)
                {
                    targetPicture = picture;
                    break;
                }
            } 

            Question newQuestion = new(questionDescription, difficultyChosen);
            newQuestion.QuestionCategory = targetCategory;
            newQuestion.QuestionPicture = targetPicture;

            // Add Object to Repository and gets ID
            newQuestion.QuestionID = QuestionRepo.Add(newQuestion);

            // Add object to ViewModel List
            QuestionVM.Add(newQuestion);

        }

        public void AddAnswer(string answerDescription, bool isItCorrect)
        {
            Answer newAnswer = new Answer(answerDescription, isItCorrect);

            newAnswer.AnswerID = AnswerRepo.Add(newAnswer);

            AnswerVM.Add(newAnswer);
        }

        public ObservableCollection<Question> GetAllQuestions()
        {
            return QuestionVM;
        }

        public ObservableCollection<Category> GetAllCategories()
        {
            return CategoryVM;
        }

        public ObservableCollection<Answer> GetAllAnswers()
        {
            return AnswerVM;
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
