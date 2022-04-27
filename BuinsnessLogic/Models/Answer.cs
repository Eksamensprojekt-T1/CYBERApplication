using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class Answer
    {
        #region // Propertys
        public int? AnswerID { get; set; }
        public string AnswerDescription { get; set; }
        public bool IsItCorrect { get; set; }
        #endregion

        #region // Constructors
        public Answer(int? answerID, string answerDescription, bool isItCorrect)
        {
            AnswerID = answerID;
            AnswerDescription = answerDescription;
            IsItCorrect = isItCorrect;
        }
        public Answer(string answerDescription, bool isItCorrect)
            : this(null, answerDescription, isItCorrect) { }

        #endregion
    }
}
