﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuinsnessLogic.Models;

namespace BuinsnessLogic.Persistence
{
    public class ParticipantRepository : IRepository<Participant>
    {
        public List<Participant> Participants { get; set; }
        private string connectionString;

        public ParticipantRepository(string connectionString)
        {
            Participants = new();
            this.connectionString = connectionString;
        }
        public int? Add(Participant participant)
        {
            int? result = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Defining SQL-Query
                string table = "PARTICIPANT";
                string coloumns = "PARTICIPANT.ParticipantName, PARTICIPANT.ParticipantNumber, PARTICIPANT.DateOfBirth, " +
                                  "PARTICIPANT.Education, PARTICIPANT.Gender, PARTICIPANT.Motivation, PARTICIPANT.ScreeningID";
                string values = "@ParticipantName, @ParticipantNumber, @DateOfBirth, @Education, @Gender, @Motivation, @ScreeningID";
                string commandText =
                    $"INSERT INTO {table} ({coloumns})" +
                    $"VALUES ({values})" +
                    $"SELECT @@IDENTITY";

                // Setting up stream to the database
                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.Parameters.Add("@ParticipantName", SqlDbType.NVarChar).Value = participant.ParticipantName;
                    cmd.Parameters.Add("@ParticipantNumber", SqlDbType.Int).Value = participant.ParticipantNumber;
                    cmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime2).Value = participant.DateOfBirth;
                    cmd.Parameters.Add("@Education", SqlDbType.NVarChar).Value = participant.Education;
                    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = participant.Gender;
                    cmd.Parameters.Add("@Motivation", SqlDbType.NVarChar).Value = participant.Motivation;
                    // cmd.Parameters.Add("@ScreeningID", SqlDbType.Int).Value = participant.screening.ScreeningID;
                    participant.ParticipantID = Convert.ToInt32(cmd.ExecuteScalar());
                    result = participant.ParticipantID;
                }
            }
            Participants.Add(participant);
            return result;
        }

        public void Delete(int? participantID)
        {
            foreach (Participant participant in Participants)
            {
                if (participant.ParticipantID.Equals(participantID))
                {
                    using (SqlConnection con = new(connectionString))
                    {
                        string table = "PARTICIPANT";
                        string commandText = $"DELETE FROM {table} WHERE {participantID} = QuestionID";

                        con.Open();
                        SqlCommand sqlCommand = new(commandText, con);
                        sqlCommand.ExecuteNonQuery();
                    }
                    Participants.Remove(participant);
                    break;
                }
            }

        }

        public IEnumerable<Participant> GetAll()
        {
            return Participants;
        }

        public Participant GetByID(int? participantID)
        {
            Participant participant = null;
            foreach (Participant currentParticipant in Participants)
            {
                if (currentParticipant.ParticipantID.Equals(participantID))
                {
                    participant = currentParticipant;
                    break;
                }
            }
            return participant;
        }

        public void Update(Participant participant)
        {
            throw new NotImplementedException();
        }

        private void loadAllEntitys()
        {

        }
    }
}
