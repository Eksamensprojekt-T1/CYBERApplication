using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BuinsnessLogic.Models.MainCategory;

namespace BuinsnessLogic.Models
{
    public class Question
    {
        #region // Properties

        public int? QuestionID { get; set; }

        public string QuestionDescription { get; set; }

        public Level Difficulty { get; set; }

        public MainCategory Category { get; set; }

        #endregion

        #region // Constructors

        public Question(int? questionID, string questionDescription, Level difficulty, MainCategory category)
        {
            QuestionID = questionID;
            QuestionDescription = questionDescription;
            Difficulty = difficulty;
            Category = category;
        }

        public Question(string questionDescription, Level difficulty, MainCategory category) 
            : this (null, questionDescription, difficulty, category) { }


        #endregion
    }
}
