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
    public class QuestionRepository : IRepository<Question>
    {
        public List<Question> QuestionsList { get; set; } = new List<Question>();
        private string connectionString;

        public QuestionRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

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
                string coloumns = "QUESTION.QuestionDescription, QUESTION.Difficulty"; // Mangler tilføjelse af kategorier og answers.
                string values = "@QuestionDescription, @Difficulty";
                string commandText =
                    $"INSERT INTO {table} ({coloumns})" +
                    $"VALUES ({values})";

                // Making the call to the database
                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.Parameters.Add("@QuestionDescription", SqlDbType.NVarChar).Value = question.QuestionDescription;
                    cmd.Parameters.Add("@Difficulty", SqlDbType.NVarChar).Value = question.Difficulty;
                    question.QuestionID = Convert.ToInt32(cmd.ExecuteScalar());
                    result = question.QuestionID;
                }

                // Add Question to local list
                QuestionsList.Add(question);

                // returns result (current QuestionID)
                return result;
            }
        }

        public void Delete(int? entityID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public Question GetByID(int? entityID)
        {
            throw new NotImplementedException();
        }

        public void Update(Question entity)
        {
            throw new NotImplementedException();
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
