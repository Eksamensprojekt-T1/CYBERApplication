namespace BuinsnessLogic.Models
{
    public class Answer
    {
        #region // Properties

        public int? AnswerID { get; set; }
        public string AnswerDescription { get; set; }
        public bool IsItCorrect { get; set; }
        public int? QuestionID { get; set; }

        #endregion

        #region // Constructors

        public Answer(int? answerID, string answerDescription, bool isItCorrect, int? questionID)
        {
            AnswerID = answerID;
            AnswerDescription = answerDescription;
            IsItCorrect = isItCorrect;
            QuestionID = questionID;
        }

        public Answer(string answerDescription, bool isItCorrect)
            : this(null, answerDescription, isItCorrect, null) { }

        #endregion
    }
}
