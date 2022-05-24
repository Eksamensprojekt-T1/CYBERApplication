using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BuinsnessLogic.Models;

namespace BuinsnessLogic.Persistence
{
    public class AnswerRepository : IRepository<Answer>
    {

        //=========================================================================
        // Fields & Properties
        //=========================================================================

        public List<Answer> Answers { get; set; }
        private string connectionString;

        //=========================================================================
        // Constructors
        //=========================================================================

        public AnswerRepository(string connectionString)
        {
            Answers = new();
            this.connectionString = connectionString;
            loadAllEntitys();
        }

        //=========================================================================
        // Add (CRUD: Create)
        // Adds an answer to the database
        //=========================================================================

        public int? Add(Answer answer)
        {
            int? result = -1;
            string table = "ANSWER";
            string coloumns = "ANSWER.AnswerDescription, ANSWER.IsItCorrect, ANSWER.QuestionID";
            string values = "@answerDescription, @isItCorrect, @QuestionID";
            string commandText =
                $"INSERT INTO {table} ({coloumns})" +
                $"VALUES ({values})" +
                $"SELECT @@IDENTITY";

            using (SqlConnection con = new(connectionString)) // gets from database
            {
                con.Open();
                SqlCommand cmd = new(commandText, con);
                cmd.Parameters.Add("@answerDescription", SqlDbType.NVarChar).Value = answer.AnswerDescription;
                cmd.Parameters.Add("@isItCorrect", SqlDbType.Bit).Value = answer.IsItCorrect;
                cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value = answer.QuestionID;
                answer.AnswerID = Convert.ToInt32(cmd.ExecuteScalar());
                result = answer.AnswerID;
            }
            Answers.Add(answer); // adds to List

            return result;
        }

        //=========================================================================
        // GetAll (CRUD: Read)
        // Returns all answer objects from the list
        //=========================================================================

        public IEnumerable<Answer> GetAll()
        {
            return Answers;
        }

        //=========================================================================
        // GetByID (CRUD: Read)
        // Returns a specific answer object.
        //=========================================================================

        public Answer GetByID(int? answerID)
        {
            Answer result = null;
            foreach (Answer answer in Answers)
            {
                if (answer.AnswerID.Equals(answerID))
                {
                    result = answer;
                    break;
                }
            }
            return result;
        }

        //=========================================================================
        // Update (CRUD: Update)
        // Updates an already existing answer in the database
        //=========================================================================

        public void Update(Answer answer)
        {
            string table = "ANSWER";
            string values = $"AnswerDescription = '{answer.AnswerDescription}', " +
                            $"IsItCorrect = '{answer.IsItCorrect}'";
            string condition = $"AnswerID = {answer.AnswerID}";
            string CommandText = 
                $"UPDATE {table}" +
                $"SET {values}" +
                $"WHERE {condition}";

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new(CommandText, connection);
                // need fix
                cmd.ExecuteScalar();
            }
        }

        //=========================================================================
        // Delete (CRUD: Delete)
        // Deletes a answer from the database
        //=========================================================================

        public void Delete(int? answerID)
        {
            if (answerID != null) // TODO should be some exception
            {
                foreach (Answer answer in Answers)
                {
                    if (answer.AnswerID.Equals(answerID))
                    {
                        // Remove from SQL database
                        using (SqlConnection connection = new(connectionString))
                        {
                            connection.Open();
                            string table = "ANSWER";
                            string commandText = $"DELETE FROM {table} WHERE {answer.AnswerID} = @AnswerID";
                            SqlCommand cmd = new(commandText, connection);
                            cmd.Parameters.Add("@AnswerID", SqlDbType.Int).Value = answer.AnswerID;
                            cmd.ExecuteNonQuery();
                            // cmd.ExecuteScalar();
                        }
                        // Removes from RAM
                        Answers.Remove(answer);

                        break;
                    }
                }
            }
        }

        //=========================================================================
        // LoadAllEnitys (CRUD: Update)
        // Loads all entities from the database table ANSWER
        //=========================================================================

        private void loadAllEntitys()
        {
            using (SqlConnection connection = new(connectionString))
            {
                string table = "ANSWER";
                string values = "ANSWER.AnswerID, ANSWER.AnswerDescription, ANSWER.IsItCorrect, ANSWER.QuestionID";
                string CommandText = $"SELECT {values} FROM {table}";

                // Loads to RAM from database
                connection.Open();
                SqlCommand sQLCommand = new(CommandText, connection);
                using (SqlDataReader sqlDataReader = sQLCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        int? answerID = int.Parse(sqlDataReader["AnswerID"].ToString());
                        string answerDescription = sqlDataReader["AnswerDescription"].ToString();
                        bool isItCorrect = sqlDataReader["IsItCorrect"].ToString() == "1";
                        int? questionID = int.Parse(sqlDataReader["QuestionID"].ToString());

                        Answer answer = new(answerID, answerDescription, isItCorrect, questionID);

                        Answers.Add(answer);
                    }
                }
            }
        }
    }
}