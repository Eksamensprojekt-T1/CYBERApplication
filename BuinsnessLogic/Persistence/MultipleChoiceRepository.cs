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

                        MultipleChoice multipleChoice = new(mcID, mcName, dateOfCreation);

                        MultipleChoicesList.Add(multipleChoice);
                    }
                }

            }

            //nyt kald for at finde count/ anatal af spørgsmål
            //select COUNT(*) from MULTIPLECHOISE_QUESTION where MCID=1
            //hvor skal det gemmes?
            using (SqlConnection con = new(connectionString))
            {
                string table = "MULTIPLECHOISE_QUESTION";
                string innerJoin = "INNER JOIN MULTIPLECHOISE on MULTIPLECHOISE.MCID = MULTIPLECHOISE_QUESTION.MCID";
                string commandText = $"SELECT COUNT(*) FROM {table} {innerJoin}";
            }

        }
    }
}
