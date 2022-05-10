using AdminApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AdminApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static OverviewViewModel ovm = new OverviewViewModel();
        public static QuestionViewModel qvm = new QuestionViewModel();
    }
}
