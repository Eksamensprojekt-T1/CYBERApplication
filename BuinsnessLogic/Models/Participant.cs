using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class Participant
    {
        public int? ParticipantID { get; set; }
        public string ParticipantName { get; set; }
        public DateTime DateOfBirht { get; set; }
        public string EducationalBackground { get; set; }
        public string Gender { get; set; }
        public string Motivation { get; set; }

        public Participant(int? participantID, string participantName, DateTime dateOfBirht, string educationalBackground, string gender, string motivation)
        {
            ParticipantID = participantID;
            ParticipantName = participantName;
            DateOfBirht = dateOfBirht;
            EducationalBackground = educationalBackground;
            Gender = gender;
            Motivation = motivation;
        }

        public Participant(string participantName, DateTime dateOfBirht, string educationalBackground, string gender, string motivation)
            : this(null, participantName, dateOfBirht, educationalBackground, gender, motivation) { }
    }
}
