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
            loadAllEntitys();
        }
        
        public int? Add(Answer answer)
        {
            int? result = -1;
            string table = "ANSWER";
            string coloumns = "ANSWER.AnswerDescription, ANSWER.IsItCorrect";
            string values = "@answerDescription, @isItCorrect";
            string commandText =
                $"INSERT INTO {table} ({coloumns})" +
                $"VALUES ({values})" +
                $"SELECT @@IDENTITY";

            using (SqlConnection con = new(connectionPath)) // gets from database
            {
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
        public IEnumerable<Answer> GetAll()
        {
            return Answers;
        }
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

            using (SqlConnection connection = new(connectionPath))
            {
                connection.Open();
                SqlCommand cmd = new(CommandText, connection);
                // need fix
                cmd.ExecuteScalar();
            }
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
        private void loadAllEntitys()
        {
            using (SqlConnection connection = new(connectionPath))
            {
                string table = "ANSWER";
                string values = "ANSWER.AnswerID, ANSWER.AnswerDescription, ANSWER.IsItCorrect";
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

                        Answer answer = new(answerID, answerDescription, isItCorrect);

                        Answers.Add(answer);
                    }
                }
            }
        }
    }
}