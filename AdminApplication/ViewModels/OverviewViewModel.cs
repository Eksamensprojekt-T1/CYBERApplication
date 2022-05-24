using BuinsnessLogic.Models;
using BuinsnessLogic.Persistence;
using System.Collections.ObjectModel;

namespace AdminApplication.ViewModels
{
    public class OverviewViewModel
    {

        //=========================================================================
        // Fields & Properties
        //=========================================================================

        // Connection string
        static private string connectionString = Properties.Settings.Default.WPF_Connection;

        // Observablecollections
        public ObservableCollection<Question> QuestionVM { get; set; } = new ObservableCollection<Question>();
        public ObservableCollection<MultipleChoice> MultipleChoiceVM { get; set; } = new ObservableCollection<MultipleChoice>();
        public ObservableCollection<Screening> ScreeningVM { get; set; } = new ObservableCollection<Screening>();

        // Repositories
        MultipleChoiceRepository MultipleChoiceRepo = new MultipleChoiceRepository(connectionString);
        QuestionRepository QuestionRepo = new QuestionRepository(connectionString);
        ScreeningRepository ScreeningRepo = new ScreeningRepository(connectionString);

        //=========================================================================
        // Constructor
        //=========================================================================

        public OverviewViewModel()
        {
            foreach (Question question in QuestionRepo.GetAll())
            {
                QuestionVM.Add(question);
            }
            foreach (MultipleChoice multipleChoice in MultipleChoiceRepo.GetAll())
            {
                MultipleChoiceVM.Add(multipleChoice);
            }
            foreach(Screening screening in ScreeningRepo.GetAll())
            {
                ScreeningVM.Add(screening);
            }
        }

    }
}
