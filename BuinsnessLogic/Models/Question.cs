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
        public Picture QuestionPicture { get; set; }
        public List<Answer> Answers { get; set; }

        #endregion

        #region // Constructors

        public Question(int? questionID, string questionDescription, Level difficulty, Category questionCategory, Picture questionPicture, List<Answer> answers)
        {
            QuestionID = questionID;
            QuestionDescription = questionDescription;
            Difficulty = difficulty;
            QuestionCategory = questionCategory;
            QuestionPicture = questionPicture;
            Answers = answers;

        }

        public Question(string questionDescription, Level difficulty, Category questionCategory)
            : this(null, questionDescription, difficulty, questionCategory, null, new List<Answer>()) { }
        
        public Question(string questionDescription, Level difficulty, Category questionCategory, List<Answer> answers)
            : this(null, questionDescription, difficulty, questionCategory, null, answers) { }
        public Question(int? questionID, string questionDescription, Level difficulty, Category questionCategory)
           : this(questionID, questionDescription, difficulty, questionCategory, null, new List<Answer>()) { }

        #endregion
    }
}
