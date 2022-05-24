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

        private ScreeningRepository screeningRepository;

        //=========================================================================
        // Constructors
        //=========================================================================

        public WelcomeViewModel()
        {

            Screenings = new();
            MultipleChoices = new();
            Questions = new();
            Answers = new();

            screeningRepository = new(connectionString);
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
