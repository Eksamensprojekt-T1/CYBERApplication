﻿using BuinsnessLogic.Models;
using BuinsnessLogic.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.ViewModels
{
    public class QuestionViewModel
    {
        // Creating connectionstring to DB
        static private string connectionString = Properties.Settings.Default.WPF_Connection;

        // Defining the ViewModel lists
        public ObservableCollection<Question> QuestionVM { get; set; } = new ObservableCollection<Question>();
        public ObservableCollection<Category> CategoryVM = new ObservableCollection<Category>();
        public ObservableCollection<Answer> AnswerVM { get; set; } = new ObservableCollection<Answer>();
        public ObservableCollection<Picture> PictureVM { get; set; } = new ObservableCollection<Picture>();

        // Defining repository objects
        QuestionRepository QuestionRepo = new QuestionRepository(connectionString);
        CategoryRepository CategoryRepo = new CategoryRepository(connectionString);
        AnswerRepository AnswerRepo = new AnswerRepository(connectionString);
        PictureRepository PictureRepo = new PictureRepository(connectionString);

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
        public void AddNewQuestion(string questionDescription, string categoryName, string difficulty, Bitmap? pictureBitmap)
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
                if (picture.PictureBitmap == pictureBitmap)
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
            AddPicture(pictureBitmap);

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

        public void AddPicture(Bitmap? bitmap)
        {
            Picture newPicture = new Picture(bitmap);

            //Add to Repo and gets ID
            newPicture.PictureID = PictureRepo.Add(newPicture);

            // Add object to ViewModel List
            PictureVM.Add(newPicture);
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
