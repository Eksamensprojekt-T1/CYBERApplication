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
    public class ParticipantWelcomeViewModel
    {
        readonly string connectionPath = Properties.Settings.Default.WPF_Connection;

        public ObservableCollection<Screening> Screenings;
        public ObservableCollection<MultipleChoice> MultipleChoices;
        public ObservableCollection<Question> Questions;
        public ObservableCollection<Answer> Answers;

        private ParticipantRepository participantRepository;
        private ScreeningRepository screeningRepository;
        private MultipleChoiceRepository multipleChoiceRepository;
        private QuestionRepository questionRepository;
        private AnswerRepository answerRepository;

        public ParticipantWelcomeViewModel()
        {

            Screenings = new();
            MultipleChoices = new();
            Questions = new();
            Answers = new();

            participantRepository = new(connectionPath);
            multipleChoiceRepository = new(connectionPath);
            screeningRepository = new(connectionPath);
            participantRepository = new(connectionPath);
            answerRepository = new(connectionPath);
            questionRepository = new(connectionPath);
        }

        public bool ScreeningExistsWithPassword(int screeningPassword)
        {
            bool result = false;
            foreach (Screening screening in screeningRepository.Screenings)
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
