using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class Participant
    {
        #region // Properties

        public int? ParticipantID { get; set; }
        public string ParticipantName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Education { get; set; }
        public string Gender { get; set; }
        public string Motivation { get; set; }


        #endregion

        #region // Constructors
        public Participant(int? participantID, string participantName, DateTime dateOfBirth, string education, string gender, string motivation)
        {
            ParticipantID = participantID;
            ParticipantName = participantName;
            DateOfBirth = dateOfBirth;
            Education = education;
            Gender = gender;
            Motivation = motivation;
        }

        public Participant(string participantName, DateTime dateOfBirth, string education, string gender, string motivation)
            : this(null, participantName, dateOfBirth, education, gender, motivation) { }

        #endregion
    }
}
