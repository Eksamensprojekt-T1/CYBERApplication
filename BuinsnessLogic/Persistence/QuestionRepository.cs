using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BuinsnessLogic.Models;

namespace BuinsnessLogic.Persistence
{
    public class QuestionRepository : IRepository<Question>
    {

        //=========================================================================
        // Fields & Properties
        //=========================================================================

        public List<Question> QuestionsList { get; set; } = new List<Question>();
        private string connectionString;

        //=========================================================================
        // Constructors
        //=========================================================================

        public QuestionRepository(string connectionString)
        {
            this.connectionString = connectionString;
            loadAllEntitys();
        }

        //=========================================================================
        // Add (CRUD: Create)
        // Adds a question to the database
        //=========================================================================

        public int? Add(Question question)
        {
            // Defining result
            int? result = -1;

            // Starts connection to database
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Defining SQL-Query
                string table = "QUESTION";
                string coloumns = "QUESTION.QuestionDescription, QUESTION.Difficulty, QUESTION.CategoryID, QUESTION.PictureID";
                string values = "@QuestionDescription, @Difficulty, @CategoryID, @PictureID";
                string commandText =
                    $"INSERT INTO {table} ({coloumns})" +
                    $"VALUES ({values})" +
                     $"SELECT @@IDENTITY";

                // Setting up stream to the database
                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.Parameters.Add("@QuestionDescription", SqlDbType.NVarChar).Value = question.QuestionDescription;
                    cmd.Parameters.Add("@Difficulty", SqlDbType.NVarChar).Value = question.Difficulty;
                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = question.QuestionCategory.CategoryID;

                    if (question.QuestionPicture != null)
                    {
                        cmd.Parameters.Add("@PictureID", SqlDbType.Int).Value = question.QuestionPicture.PictureID;
                    }
                    else
                    {
                        cmd.Parameters.Add("@PictureID", SqlDbType.Int).Value = DBNull.Value;
                    }

                    question.QuestionID = Convert.ToInt32(cmd.ExecuteScalar());
                    result = question.QuestionID;
                }

                // Add Question to local list
                QuestionsList.Add(question);
            }
            // returns result (current QuestionID)
            return result;
        }

        //=========================================================================
        // GetAll (CRUD: Read)
        // Returns all question objects from list
        //=========================================================================

        public IEnumerable<Question> GetAll()
        {
            return QuestionsList;
        }

        //=========================================================================
        // GetByID (CRUD: Read)
        // Returns a specific question object.
        //=========================================================================

        public Question GetByID(int? entityID)
        {
            throw new NotImplementedException();
        }

        //=========================================================================
        // Update (CRUD: Update)
        // Updates a already existing question object
        //=========================================================================

        public void Update(Question entity)
        {
            throw new NotImplementedException();
        }

        //=========================================================================
        // Delete (CRUD: Delete)
        // Removes a question from the database
        //=========================================================================

        public void Delete(int? entityID)
        {
            using (SqlConnection con = new(connectionString))
            {
                string questionTable = "QUESTION";
                string answerTable = "ANSWER";
                string multipleChoiceTable = "MULTIPLECHOICE_QUESTION";
                string commandText = $"DELETE from {multipleChoiceTable} WHERE QuestionID = {entityID}; DELETE FROM {answerTable} WHERE QuestionID = {entityID}; DELETE FROM {questionTable} WHERE {entityID} = QuestionID";

                con.Open();
                SqlCommand sqlCommand = new(commandText, con);
                sqlCommand.ExecuteNonQuery();

                foreach (Question question in QuestionsList)
                {
                    if (question.QuestionID == entityID)
                    {
                        QuestionsList.Remove(question);
                        break;
                    }
                }

            }
        }

        //=========================================================================
        // LoadAllEntitys (CRUD: Read)
        // Loads all entities from the database table QUESTION
        //=========================================================================

        private void loadAllEntitys()
        {
            using (SqlConnection con = new(connectionString))
            {
                string table = "QUESTION";
                string values = "QUESTION.QuestionID, QUESTION.QuestionDescription, QUESTION.Difficulty, QUESTION.PictureID, QUESTION.CategoryID, CATEGORY.CategoryName";
                string innerJoin = "INNER JOIN CATEGORY on QUESTION.CategoryID = CATEGORY.CategoryID";
                string CommandText = $"SELECT {values} FROM {table} {innerJoin}";

                con.Open();
                SqlCommand sQLCommand = new(CommandText, con);
                using (SqlDataReader reader = sQLCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int? questionID = int.Parse(reader["QuestionID"].ToString());
                        string questionDescription = reader["QuestionDescription"].ToString();
                        string questionDifficulty = reader["Difficulty"].ToString();
                        string questionCategoryName = reader["CategoryName"].ToString();

                        int diff = 0;

                        switch (questionDifficulty)
                        {
                            case "Nem":
                                diff = 0;
                                break;
                            case "Moderat":
                                diff = 1;
                                break;
                            case "Svær":
                                diff = 2;
                                break;
                        }

                        Question question = new(questionID, questionDescription, (Level)diff, new Category(questionCategoryName));
                        fillAnswersForQuestion(question);
                        QuestionsList.Add(question);
                    }
                }
            }
        }

        //=========================================================================
        // fillAnswersForQuestion (CRUD: Read)
        // Adds all answers in relation to the referenced with the given question
        //=========================================================================

        private void fillAnswersForQuestion(Question question)
        {
            using (SqlConnection con = new(connectionString))
            {
                string table = "ANSWER";
                string values = "ANSWER.AnswerID, ANSWER.AnswerDescription ,ANSWER.IsItCorrect";
                string commandText = $"SELECT {values} FROM {table} WHERE QuestionID = {question.QuestionID}; ";

                con.Open();

                using (SqlCommand sQLCommand = new(commandText, con))
                {
                    using (SqlDataReader reader = sQLCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int? answerID = int.Parse(reader["AnswerID"].ToString());
                            string answerDescription = reader["AnswerDescription"].ToString();
                            bool isItCorrect = reader["IsItCorrect"].ToString() == "1";
                            Answer answer = new(answerID, answerDescription, isItCorrect, question.QuestionID);
                            question.Answers.Add(answer);
                        }
                    }
                }
            }
        }
    }
}
