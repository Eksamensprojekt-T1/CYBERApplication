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
    public class WelcomeViewModel
    {

        //=========================================================================
        // Fields & Properties
        //=========================================================================

        readonly string connectionString = Properties.Settings.Default.WPF_Connection;

        public ObservableCollection<Screening> Screenings;
        public ObservableCollection<MultipleChoice> MultipleChoices;
        public ObservableCollection<Question> Questions;
        public ObservableCollection<Answer> Answers;

        private ParticipantRepository participantRepository;
        private ScreeningRepository screeningRepository;
        private MultipleChoiceRepository multipleChoiceRepository;
        private QuestionRepository questionRepository;
        private AnswerRepository answerRepository;

        //=========================================================================
        // Constructors
        //=========================================================================

        public WelcomeViewModel()
        {

            Screenings = new();
            MultipleChoices = new();
            Questions = new();
            Answers = new();

            participantRepository = new(connectionString);
            multipleChoiceRepository = new(connectionString);
            screeningRepository = new(connectionString);
            participantRepository = new(connectionString);
            answerRepository = new(connectionString);
            questionRepository = new(connectionString);
        }

        //=========================================================================
        // ScreeningExistsWithPassword (CRUD: Read)
        // Checks if the typed password match with any screenings created
        //=========================================================================

        public bool ScreeningExistsWithPassword(int screeningPassword)
        {
            bool result = false;
            foreach (Screening screening in screeningRepository.ScreeningsList)
            {
                if (screening.ScreeningPassword == screeningPassword)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
