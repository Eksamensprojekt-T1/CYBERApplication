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
                // insert multiplechoice
                string multipleChoiceTable = "MULTIPLECHOICE";
                string columns = "MULTIPLECHOICE.MCName, MULTIPLECHOICE.DateOfCreation";
                string values = "@MCName, @DateOfCreation";
                string commandText = $"INSERT INTO {multipleChoiceTable} ({columns}) VALUES ({values}) SELECT @@IDENTITY";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.Parameters.Add("@MCName", SqlDbType.NVarChar).Value = multipleChoice.MCName;
                    cmd.Parameters.Add("@DateOfCreation", SqlDbType.DateTime2).Value = multipleChoice.DateOfCreation;
                    multipleChoice.MCID = Convert.ToInt32(cmd.ExecuteScalar());
                    result = multipleChoice.MCID;
                }

                foreach(Question question in multipleChoice.Questions)
                {
                    AddQuestions(multipleChoice, question);
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
                string table = "MULTIPLECHOICE";
                string commandText = $"DELETE FROM MULTIPLECHOICE_QUESTION WHERE {entityID} = MCID; DELETE FROM {table} WHERE {entityID} = MCID";

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
            MultipleChoice result = null;
            int count = 0;

            try
            {
                foreach (MultipleChoice multipleChoice in MultipleChoicesList)
                {
                    if (multipleChoice.MCID.Equals(entityID))
                    {
                        result = multipleChoice;
                        break;
                    }
                    count++;
                }
            }
            catch (Exception e) when (entityID is null)
            {
                string message = "Multiplechoice ID is not set.";
                throw new Exception(message, e);
            }
            catch (Exception e) when (count == MultipleChoicesList.Count)
            {
                string message = "Multiplechoice ID does not exist.";
                throw new Exception(message, e);
            }

            return result;
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
                string table = "MULTIPLECHOICE";
                string values = "MULTIPLECHOICE.MCID, MULTIPLECHOICE.MCName, MULTIPLECHOICE.DateOfCreation";
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
        // AddQuestions (CRUD: Create)
        // Inserts the MCID and questionID into MULTIPLECHOICE_QUESTION to create the relation between them
        //=========================================================================

        private void AddQuestions(MultipleChoice multipleChoice, Question question)
        {
            // insert multipleChoice_Question
            string mqTable = "MULTIPLECHOICE_QUESTION";
            string columns = "MULTIPLECHOICE_QUESTION.MCID, MULTIPLECHOICE_QUESTION.QuestionID";
            string values = "@MCID, @QuestionID";
            string commandText = $"INSERT INTO {mqTable} ({columns}) VALUES ({values})";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.Parameters.Add("@MCID", SqlDbType.Int).Value = multipleChoice.MCID;
                    cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value = question.QuestionID;
                    cmd.ExecuteNonQuery();
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
                string values = "MULTIPLECHOICE.MCID, QUESTION.QuestionID, QUESTION.QuestionDescription, QUESTION.Difficulty, CATEGORY.CategoryName";
                string innerJoin1 = "INNER JOIN MULTIPLECHOICE_QUESTION on MULTIPLECHOICE.MCID = MULTIPLECHOICE_QUESTION.MCID";
                string innerJoin2 = "INNER JOIN QUESTION on MULTIPLECHOICE_QUESTION.QuestionID = QUESTION.QuestionID";
                string innerJoin3 = "INNER JOIN CATEGORY on QUESTION.CategoryID = CATEGORY.CategoryID";
                string where = $"WHERE MULTIPLECHOICE.MCID = {id}";
                string commandText = $"SELECT {values} FROM MULTIPLECHOICE {innerJoin1} {innerJoin2} {innerJoin3} {where}";

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
