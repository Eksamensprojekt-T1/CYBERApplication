using System;

namespace BuinsnessLogic.Models
{
    public class Report
    {
        #region // Properties

        public int? ReportID { get; set; }
        public string ReportName { get; set; }
        public DateTime ReportDate { get; set; }

        #endregion

        #region // Constructors

        public Report(int? reportID, string reportName, DateTime reportDate)
        {
            ReportID = reportID;
            ReportName = reportName;
            ReportDate = reportDate; //  = DateTime.Now; 
        }
        public Report(string reportName, DateTime reportDate)   
            : this(null, reportName, reportDate) { }

        #endregion

    }
}
