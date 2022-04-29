using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class Screening
    {
        #region // Properties

        public int? ScreeningID { get; set; }
        public string ScreeningName { get; set; }
        public int ScreeningPassword { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Timer ScreeningTimer { get; set; }


        #endregion

        #region // Constructors

        public Screening(int? screeningID, string screeningName, int screeningPassword, DateTime startDate, DateTime endDate, Timer screeningTimer)
        {
            ScreeningID = screeningID;
            ScreeningName = screeningName;
            ScreeningPassword = screeningPassword;
            StartDate = startDate;
            EndDate = endDate;
            ScreeningTimer = screeningTimer;
        }

        public Screening(string screeningName, int screeningPassword, DateTime startDate, DateTime endDate, Timer screeningTimer)
            : this(null, screeningName, screeningPassword, startDate, endDate, screeningTimer) { }

        #endregion

    }
}
