using AdminApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdminApplication.Views
{
    /// <summary>
    /// Interaction logic for MultipleChoiceCreatorPage.xaml
    /// </summary>
    public partial class MultipleChoiceCreatorPage : Page
    {
        MultipleChoiceCreatorViewModel mccvm = new MultipleChoiceCreatorViewModel();
        
        public MultipleChoiceCreatorPage()
        {
            InitializeComponent();
            DataContext = mccvm;
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/MultipleChoiceOverviewPage.xaml", UriKind.Relative));
        }

        private void Question_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Approve_btn_Click(object sender, RoutedEventArgs e)
        {
            string mCName = MultipleChoice_tb.Text;
            DateTime dateOfCreation = DateTime.Now;
            //bool isSelected = false;

            mccvm.AddMultipleChoice(mCName, dateOfCreation);
            
            //mccvm.AddMultipleChoice_Question(isSelected);

            NavigationService.Navigate(new Uri("Views/MultipleChoiceOverviewPage.xaml", UriKind.Relative));
            MessageBox.Show("Multiple Choice oprettet!", "Meddelelse", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }
    }
}
