using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuinsnessLogic.Models;
using BuinsnessLogic.Persistence;
using System.Collections.ObjectModel;


namespace ScreeningApplication.ViewModels
{
    public class InfoViewModel
    {
        readonly string connectionPath = Properties.Settings.Default.WPF_Connection;
        private ParticipantRepository participantRepository;
        public InfoViewModel()
        {
            participantRepository = new(connectionPath);
        }

        public void StartScreening(string participantName, DateTime dateOfBirth, string education, string gender, string motivation)
        {
            Participant participant = new(participantName, dateOfBirth, education, gender, motivation);
            participantRepository.Add(participant);
        }
    }
}
