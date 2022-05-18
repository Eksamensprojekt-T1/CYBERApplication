using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class Screening
    {
        private int screeningTimer;
        #region // Properties

        public int? ScreeningID { get; set; }
        public string ScreeningName { get; set; }
        public int ScreeningPassword { get; set; }
        public double PassingScore { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Timer ScreeningTimer { get; set; }


        #endregion

        #region // Constructors

        public Screening(int? screeningID, string screeningName, int screeningPassword, double passingScore, DateTime startDate, DateTime endDate, int screeningTimer)
        {
            ScreeningID = screeningID;
            ScreeningName = screeningName;
            ScreeningPassword = screeningPassword;
            PassingScore = passingScore;
            StartDate = startDate;
            EndDate = endDate;
            this.screeningTimer = screeningTimer;
        }

        public Screening(string screeningName, int screeningPassword, double passingScore, DateTime startDate, DateTime endDate, int screeningTimer)
            : this(null, screeningName, screeningPassword, passingScore, startDate, endDate, screeningTimer) { }


        #endregion

    }
}
