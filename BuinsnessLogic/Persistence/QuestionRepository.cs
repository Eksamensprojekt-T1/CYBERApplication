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
                string coloumns = "QUESTION.QuestionDescription, QUESTION.Difficulty, QUESTION.CategoryID, QUESTION.PictureID"; // Mangler tilføjelse af answers.
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

                        Question question = new(questionID, questionDescription, (Level)diff, new Category(questionCategoryName), new Picture("", ""));

                        QuestionsList.Add(question);
                    }
                }
            }
        }
    }
}
