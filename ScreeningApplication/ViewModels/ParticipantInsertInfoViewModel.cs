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
    public class ParticipantInsertInfoViewModel
    {
        readonly string connectionPath = Properties.Settings.Default.WPF_Connection;
        private ParticipantRepository participantRepository;
        public ParticipantInsertInfoViewModel()
        {
            participantRepository = new(connectionPath);
        }

        public void MakeAndLoadParticipant(string name, DateTime dob, string education, string gender, string motivation)
        {
            Participant participant = new(name, dob, education, gender, motivation);
            participantRepository.Add(participant);
        }
    }
}
