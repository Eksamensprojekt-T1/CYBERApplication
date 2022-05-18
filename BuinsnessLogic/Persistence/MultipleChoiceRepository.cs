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

        //=========================================================================
        // Fields & Properties
        //=========================================================================

        public List<MultipleChoice> MultipleChoicesList { get; set; } = new List<MultipleChoice>();

        private string connectionString;

        //=========================================================================
        // Constructors
        //=========================================================================

        public MultipleChoiceRepository(string connectionString)
        {
            this.connectionString = connectionString;
            loadAllEntitys();
        }

        //=========================================================================
        // Add (CRUD: Create)
        // Adds a multiple choice to the database
        //=========================================================================

        public int? Add(MultipleChoice multipleChoice)
        {
            //Defining result
            int? result = -1;

            // Starts connection to database
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string table = "MULTIPLECHOISE";
                string colums = "MULTIPLECHOISE.MCName, MULTIPLECHOISE.DateOfCreation";
                string values = "@MCName, @DateOfCreation";
                string commandText =
                    $"INSERT INTO {table}({colums})" +
                    $"VALUES ({values})" +
                    $"SELECT @@IDENTITY";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.Parameters.Add("@MCName", SqlDbType.NVarChar).Value = multipleChoice.MCName;
                    cmd.Parameters.Add("@DateOfCreation", SqlDbType.DateTime2).Value = multipleChoice.DateOfCreation;
                    multipleChoice.MCID = Convert.ToInt32(cmd.ExecuteScalar());
                    result = multipleChoice.MCID;
                }

                MultipleChoicesList.Add(multipleChoice);

                return result;
            }
        }

        //=========================================================================
        // Delete (CRUD: Delete)
        // Removes a multiplechoice from the database
        //=========================================================================

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

        //=========================================================================
        // GetAll (CRUD: Read)
        // Returns all multiplechoice objects from database
        //=========================================================================

        public IEnumerable<MultipleChoice> GetAll()
        {
            return MultipleChoicesList;
        }

        //=========================================================================
        // GetByID (CRUD: Read)
        // Returns a specific multiple choice object.
        //=========================================================================

        public MultipleChoice GetByID(int? entityID)
        {
            throw new NotImplementedException();
        }

        //=========================================================================
        // Update (CRUD: Update)
        // Updates a already existing multiplechoice object
        //=========================================================================

        public void Update(MultipleChoice entity)
        {
            throw new NotImplementedException();
        }

        //=========================================================================
        // LoadAllEntitys (CRUD: Read)
        // Loads all objects from the MULTIPLECHOICE table in the database
        // to the Repository list
        //=========================================================================

        private void loadAllEntitys()
        {
            using (SqlConnection con = new(connectionString))
            {
                string table = "MULTIPLECHOISE";
                string values = "MULTIPLECHOISE.MCID, MULTIPLECHOISE.MCName, MULTIPLECHOISE.DateOfCreation";
                string commandText = $"SELECT {values} FROM {table}";

                con.Open();
                using (SqlCommand sqlCommand = new(commandText, con))
                {
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
        }

        //=========================================================================
        // MakeListOfQuestions (CRUD: Create)
        // Returns a lists with questions in relation to the multiple choice id chosen
        //=========================================================================

        private List<Question> MakeListOfQuestions(int? id)
        {
            List<Question> list = new List<Question>();

            using (SqlConnection con = new(connectionString))
            {
                string values = "MULTIPLECHOISE.MCID, QUESTION.QuestionID, QUESTION.QuestionDescription, QUESTION.Difficulty, CATEGORY.CategoryName";
                string innerJoin1 = "INNER JOIN MULTIPLECHOISE_QUESTION on MULTIPLECHOISE.MCID = MULTIPLECHOISE_QUESTION.MCID";
                string innerJoin2 = "INNER JOIN QUESTION on MULTIPLECHOISE_QUESTION.QuestionID = QUESTION.QuestionID";
                string innerJoin3 = "INNER JOIN CATEGORY on QUESTION.CategoryID = CATEGORY.CategoryID";
                string where = $"WHERE MULTIPLECHOISE.MCID = {id}";
                string commandText = $"SELECT {values} FROM MULTIPLECHOISE {innerJoin1} {innerJoin2} {innerJoin3} {where}";

                con.Open();
                using (SqlCommand sQLCommand = new(commandText, con))
                {
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
                                    difficulty = Level.Nem;
                                    break;
                            }

                            Question question = new Question(questionID, questionDesc, difficulty, new Category(categoryName));

                            list.Add(question);
                        }
                    }
                }
            }

            return list;
        }
    }
}
