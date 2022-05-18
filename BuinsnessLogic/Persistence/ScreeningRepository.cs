using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using BuinsnessLogic.Models;

namespace BuinsnessLogic.Persistence
{
    public class ScreeningRepository : IRepository<Screening>
    {
       
        //=========================================================================
        // Fields & Properties
        //=========================================================================
        public List<Screening> ScreeningsList { get; set; } = new List<Screening>();
        
        private string connectionString;

        //=========================================================================
        // Constructors
        //=========================================================================
        public ScreeningRepository(string connectionString)
        {
            this.connectionString = connectionString;
            loadAllEntitys();
        }

        //=========================================================================
        // Add (CRUD: Create)
        // Adds a multiple choice to the database
        //=========================================================================
        public int? Add(Screening screening)
        {
            //Defining result
            int? result = -1;

            // Starts connection to database
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string table = "SCREENING";
                string colums = "SCREENING.ScreeningName, SCREENING.ScreeningPassword, SCREENING.PassingScore, SCREENING.StartDate, SCREENING.EndDate, SCREENING.ScreeningTimer";
                string values = "@ScreeningName, @ScreeningPassword, @PassingScore, @StartDate, @EndDate, @ScreeningTimer";
                string commandText =
                    $"INSERT INTO {table}({colums})" +
                    $"VALUES ({values})" +
                    $"SELECT @@IDENTITY";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.Parameters.Add("@ScreeningName", SqlDbType.NVarChar).Value = screening.ScreeningName;
                    cmd.Parameters.Add("@ScreeningPassword", SqlDbType.Int).Value = screening.ScreeningPassword;
                    cmd.Parameters.Add("@PassingScore", SqlDbType.Float).Value = screening.PassingScore;
                    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime2).Value = screening.StartDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime2).Value = screening.EndDate;
                    cmd.Parameters.Add("@ScreeningTimer", SqlDbType.Int).Value = screening.ScreeningTimer;
                    screening.ScreeningID = Convert.ToInt32(cmd.ExecuteScalar());
                    result = screening.ScreeningID;
                }

                ScreeningsList.Add(screening);

                return result;
            }
        }

        public void Delete(int? screeningID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Screening> GetAll()
        {
            return ScreeningsList;
        }

        public Screening GetByID(int? screeningID)
        {
            throw new NotImplementedException();
        }

        public void Update(Screening screening)
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
                string table = "SCREENING";
                string values = "SCREENING.ScreeningID, SCREENING.ScreeningName, SCREENING.ScreeningPassword, SCREENING.PassingScore, SCREENING.StartDate, SCREENING.EndDate, SCREENING.ScreeningTimer";
                string commandText = $"SELECT {values} FROM {table}";

                con.Open();
                using (SqlCommand sqlCommand = new(commandText, con))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int? screeningID = int.Parse(reader["ScreeningID"].ToString());
                            string screeningName = reader["ScreeningName"].ToString();
                            int screeningPassword = int.Parse(reader["ScreeningPassword"].ToString());
                            double passingScore = double.Parse(reader["PassingScore"].ToString());
                            DateTime startDate = DateTime.Parse(reader["StartDate"].ToString());
                            DateTime endDate = DateTime.Parse(reader["EndDate"].ToString());
                            int screeningTimer = int.Parse(reader["ScreeningTimer"].ToString());

                            Screening screening = new(screeningID, screeningName, screeningPassword, passingScore, startDate, endDate, screeningTimer);

                            ScreeningsList.Add(screening); 
                        }
                    }
                }
            }
        }
    }
}
