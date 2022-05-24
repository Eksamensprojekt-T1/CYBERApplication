using System;
using BuinsnessLogic.Models;
using BuinsnessLogic.Persistence;


namespace ScreeningApplication.ViewModels
{
    public class InfoViewModel
    {

        //=========================================================================
        // Fields & Properties
        //=========================================================================

        readonly string connectionString = Properties.Settings.Default.WPF_Connection;
        private ParticipantRepository participantRepository;

        //=========================================================================
        // Constructors
        //=========================================================================

        public InfoViewModel()
        {
            participantRepository = new(connectionString);
        }

        //=========================================================================
        // StartScreening (CRUD: Create)
        // Starts a screening
        //=========================================================================

        public void StartScreening(string participantName, int participantNumber, DateTime dateOfBirth, string education, string gender, string motivation)
        {
            Participant participant = new(participantName, participantNumber, dateOfBirth, education, gender, motivation);
            participantRepository.Add(participant);
        }
    }
}
