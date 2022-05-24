using System;
using System.Timers;

namespace BuinsnessLogic.Models
{
    public class Screening
    {
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

        public Screening(int? screeningID, string screeningName, int screeningPassword, double passingScore, DateTime startDate, DateTime endDate, Timer screeningTimer)
        {
            ScreeningID = screeningID;
            ScreeningName = screeningName;
            ScreeningPassword = screeningPassword;
            PassingScore = passingScore;
            StartDate = startDate;
            EndDate = endDate;
            ScreeningTimer = screeningTimer;
        }

        public Screening(int? screeningID, string screeningName, int screeningPassword, double passingScore, DateTime startDate, DateTime endDate)
            : this(screeningID, screeningName, screeningPassword, passingScore, startDate, endDate, null) { }


        #endregion

    }
}
