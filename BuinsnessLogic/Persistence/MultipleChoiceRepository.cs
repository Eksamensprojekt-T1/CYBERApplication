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
    public class MultipleChoiceRepository : IRepository<MultipleChoice>
    {

        // Create list of MultipleChoices and prepare connection
        public List<MultipleChoice> MultipleChoicesList { get; set; } = new List<MultipleChoice>();

        private string connectionString;

        //Create a constructor that takes connectionsting af argument for VM
        public MultipleChoiceRepository(string connectionString)
        {
            this.connectionString = connectionString;
            loadAllEntitys();
        }

        public int? Add(MultipleChoice multipleChoice)
        {
            //Defining result
            int? result = -1;

            // Starts connection to database
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Defining SQL-Query
                string table = "MULTIPLECHOISE";
                string colums = "MULTIPLECHOISE.MCName, MULTIPLECHOISE.DateOfCreation";
                string values = "@MCName, @DateOfCreation";
                string commandText =
                    $"INSERT INTO {table}({colums})" +
                    $"VALUES ({values})" +
                    $"SELECT @@IDENTITY";

                // Setting up stream to the database
                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.Parameters.Add("@MCName", SqlDbType.NVarChar).Value = multipleChoice.MCName;
                    cmd.Parameters.Add("@DateOfCreation", SqlDbType.DateTime2).Value = multipleChoice.DateOfCreation;
                    multipleChoice.MCID = Convert.ToInt32(cmd.ExecuteScalar());
                    result = multipleChoice.MCID;
                }

                //Add Multiple Choice to a local list
                MultipleChoicesList.Add(multipleChoice);

                // returns result (current QuestionID)
                return result;
            }
        }

        public void Delete(int? entityID)
        {
            using (SqlConnection con = new(connectionString))
            {
                string table = "MULTIPLECHOISE";
                string commandText = $"DELETE FROM {table} WHERE {entityID} = MCID";

                con.Open();
                SqlCommand sqlCommand = new(commandText, con);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public IEnumerable<MultipleChoice> GetAll()
        {
            return MultipleChoicesList;
        }

        public MultipleChoice GetByID(int? entityID)
        {
            throw new NotImplementedException();
        }

        public void Update(MultipleChoice entity)
        {
            throw new NotImplementedException();
        }
        private void loadAllEntitys()
        {
            using (SqlConnection con = new(connectionString))
            {
                string table = "MULTIPLECHOISE";
                string values = "MULTIPLECHOISE.MCID, MULTIPLECHOISE.MCName, MULTIPLECHOISE.DateOfCreation";
                string commandText = $"SELECT {values} FROM {table}";

                con.Open();
                SqlCommand sqlCommand = new(commandText, con);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int? mcID = int.Parse(reader["MCID"].ToString());
                        string mcName = reader["MCName"].ToString();
                        DateTime dateOfCreation = DateTime.Parse(reader["DateOfCreation"].ToString());

                        MultipleChoice multipleChoice = new(mcID, mcName, dateOfCreation, MakeListOfQuestions(mcID));

                        MultipleChoicesList.Add(multipleChoice);

                    }
                }

            }
        }

        private List<Question> MakeListOfQuestions(int? id)
        {
            List<Question> list = new List<Question>();

            using (SqlConnection con = new(connectionString))
            {
                string values = "MULTIPLECHOISE.MCID, QUESTION.QuestionID, QUESTION.QuestionDescription, QUESTION.Difficulty, CATEGORY.CategoryName";
                string innerJoin1 = "INNER JOIN MULTIPLECHOISE_QUESTION as mq on MULTIPLECHOISE.MCID = mq.MCID";
                string innerJoin2 = "INNER JOIN QUESTION on mq.QuestionID = QUESTION.QuestionID";
                string innerJoin3 = "INNER JOIN CATEGORY on QUESTION.CategoryID = CATEGORY.CategoryID";
                string where = $"WHERE MULTIPLECHOISE.MCID = {id}";
                string commandText = $"SELECT {values} FROM MULTIPLECHOISE {innerJoin1} {innerJoin2} {innerJoin3} {where}";

                con.Open();
                SqlCommand sQLCommand = new(commandText, con);
                using (SqlDataReader reader = sQLCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int? questionID = int.Parse(reader["QuestionID"].ToString());
                        string questionDesc = reader["QuestionDescription"].ToString();
                        string questionDifficulty = reader["Difficulty"].ToString();
                        string categoryName = reader["CategoryName"].ToString();

                        Level difficulty;

                        switch (questionDifficulty)
                        {
                            case "Nem":
                                difficulty = Level.Nem;
                                break;
                            case "Moderat":
                                difficulty = Level.Moderat;
                                break;
                            case "Svær":
                                difficulty = Level.Svær;
                                break;
                            default:
                                difficulty= Level.Nem;
                                break;
                                    
                        }

                        Question question = new Question(questionID, questionDesc, difficulty, new Category(categoryName));

                        list.Add(question);
                    }
                }

                return list;
            }
        }
    }
}
