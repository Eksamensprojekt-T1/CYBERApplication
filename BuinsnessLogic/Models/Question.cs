using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class Question
    {
        #region // Properties

        public int? QuestionID { get; set; }

        public string QuestionDescription { get; set; }

        public Level Difficulty { get; set; }

        public Category QuestionCategory { get; set; }

        public Picture? QuestionPicture { get; set; }

        #endregion

        #region // Constructors

        public Question(int? questionID, string questionDescription, Level difficulty, Category questionCategory, Picture? questionPicture)
        {
            QuestionID = questionID;
            QuestionDescription = questionDescription;
            Difficulty = difficulty;
            QuestionCategory = questionCategory;
            QuestionPicture = questionPicture;
        }

        public Question(int? questionID, string questionDescription, Level difficulty)
           : this(questionID, questionDescription, difficulty,null,null) { }

        public Question(string questionDescription, Level difficulty, Category questionCategory)
           : this(null, questionDescription, difficulty, questionCategory, null) { }

        public Question(string questionDescription, Level difficulty, Picture? questionPicture)
            : this(null, questionDescription, difficulty, null, questionPicture) { }

        public Question(string questionDescription, Level difficulty) 
            : this (null, questionDescription, difficulty) { }

        #endregion
    }
}
