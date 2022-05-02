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
            loadAllEntitys();
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

                // Setting up stream to the database
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
            return QuestionsList;
        }

        public Question GetByID(int? entityID)
        {
            throw new NotImplementedException();
        }

        public void Update(Question entity)
        {
            throw new NotImplementedException();
        }
        private void loadAllEntitys()
        {
            using (SqlConnection con = new(connectionString))
            {
                string table = "QUESTION";
                string values = "QUESTION.QuestionID, QUESTION.QuestionDescription, Question.Difficulty";
                string CommandText = $"SELECT {values} FROM {table}";

                con.Open();
                SqlCommand sQLCommand = new(CommandText, con);
                using (SqlDataReader reader = sQLCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int? questionID = int.Parse(reader["QuestionID"].ToString());
                        string questionDescription = reader["QuestionDescription"].ToString();
                        string questionDifficulty = reader["Difficulty"].ToString();

                        int diff = 0;

                        switch (questionDifficulty)
                        {
                            case "easy":
                                diff = 0;
                                break;
                            case "moderate":
                                diff = 1;
                                break;
                            case "hard":
                                diff = 2;
                                break;
                        }

                        Question question = (questionID != -1)
                            ? new(questionID, questionDescription, (Level)diff)
                            : new(questionDescription, (Level)diff);

                        QuestionsList.Add(question);
                    }
                }
            }
        }
    }
}
