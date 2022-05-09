using BuinsnessLogic.Models;
using BuinsnessLogic.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.ViewModels
{
    public class MultipleChoiceOverviewViewModel
    {
        // Creating connectionstring to DB
        static private string ConnectionString = Properties.Settings.Default.WPF_Connection;

        // Defining the ViewModel lists
        public ObservableCollection<MultipleChoice> MultipleChoiceVM { get; set; } = new ObservableCollection<MultipleChoice>();

        // Defining repository objects
        MultipleChoiceRepository MultipleChoiceRepo = new MultipleChoiceRepository(ConnectionString);

        //Constructor for adding object to observable collection
        public MultipleChoiceOverviewViewModel()
        {
            foreach (MultipleChoice multipleChoice in MultipleChoiceRepo.GetAll())
            {
                MultipleChoiceVM.Add(multipleChoice);
            }
        }

        public void DeleteMultipleChoice(object selectedItem)
        {
            MultipleChoice multipleChoice = (MultipleChoice)selectedItem;

            for (int i = 0; i < MultipleChoiceVM.Count; i++)
            {
                if (multipleChoice.MCID == MultipleChoiceVM[i].MCID)
                {
                    MultipleChoiceRepo.Delete(MultipleChoiceVM[i].MCID);
                    MultipleChoiceVM.Remove(MultipleChoiceVM[i]);
                }
            }

        }
    }
}
