using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuinsnessLogic.Models;

namespace BuinsnessLogic.Persistence
{
    public class AnswerRepository : IRepository<Answer>
    {
        public List<Answer> Answers { get; set; }
        private string connectionPath;
        public AnswerRepository(string connectionPath)
        {
            Answers = new();
            this.connectionPath = connectionPath;
            Update();
        }

        public int? Add(Answer answer)
        {
            int? result = -1;

            using (SqlConnection con = new(connectionPath)) // adds to database
            {
                string table = "ANSWER";
                string coloumns = "ANSWER.AnswerDescription, ANSWER.IsItCorrect";
                string values = "@answerDescription, @isItCorrect";
                string commandText =
                    $"INSERT INTO {table} ({coloumns})" +
                    $"VALUES ({values})";

                con.Open();
                SqlCommand cmd = new(commandText, con);
                cmd.Parameters.Add("@answerDescription", SqlDbType.NVarChar).Value = answer.AnswerDescription;
                cmd.Parameters.Add("@isItCorrect", SqlDbType.Bit).Value = answer.IsItCorrect;
                answer.AnswerID = Convert.ToInt32(cmd.ExecuteScalar());
                result = answer.AnswerID;
            }
            Answers.Add(answer); // adds to List

            return result;
        }

        public void Delete(int? answerID)
        {
            if (answerID != null) // TODO should be some exception
            {
                foreach (Answer answer in Answers)
                {
                    if (answer.AnswerID.Equals(answerID))
                    {
                        // Remove from SQL database
                        using (SqlConnection connection = new(connectionPath))
                        {
                            connection.Open();
                            string table = "ANSWER";
                            string query = $"DELETE FROM {table} WHERE {answer.AnswerID} = @AnswerID";
                            SqlCommand cmd = new(query, connection);
                            cmd.Parameters.Add("@AnswerID", SqlDbType.Int).Value = answerID;
                            cmd.ExecuteScalar();
                        }
                        // Removes from RAM
                        Answers.Remove(answer);

                        break;
                    }
                }
            }
        }

        public IEnumerable<Answer> GetAll()
        {
            return Answers;
        }

        public Answer GetByID(int? entityID)
        {
            Answer result = null;
            foreach (Answer answer in Answers)
            {
                if (answer.AnswerID.Equals(entityID))
                {
                    result = answer;
                    break;
                }
            }
            return result;
        }

        public void Update(Answer entity) // TODO
        {
            using (SqlConnection connection = new(connectionPath))
            {
                
            }
        }
        public void Update()
        {   
            using (SqlConnection connection = new(connectionPath))
            {
                string table = "ANSWER";
                string values = "ANSWER.AnswerID, ANSWER.AnswerDescription, ANSWER.IsItCorrect";
                string CommandText = $"SELECT {values} FROM {table}";

                // Loads to RAM from database
                connection.Open();
                SqlCommand sQLCommand = new(CommandText, connection);
                using (SqlDataReader sqldatareader = sQLCommand.ExecuteReader())
                {
                    while (sqldatareader.Read())
                    {
                        int? answerID = int.Parse(sqldatareader["AnswerID"].ToString());
                        string answerDescription = sqldatareader["AnswerDescription"].ToString();
                        bool isItCorrect = sqldatareader["IsItCorrect"].ToString() == "1";

                        Answer answer = (answerID != -1) // Ternary
                            ? new(answerID, answerDescription, isItCorrect)
                            : new(answerDescription, isItCorrect);

                        Answers.Add(answer);
                    }
                }
            }
        }
    }
}