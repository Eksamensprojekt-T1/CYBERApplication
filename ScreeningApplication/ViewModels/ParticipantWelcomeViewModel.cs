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
        readonly string connectionPath;

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
            connectionPath = "Server=10.56.8.36;Database=PEDB01;User Id=PE-01;Password=OPENDB_01;";

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
    }
}
