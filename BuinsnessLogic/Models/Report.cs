using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class Report
    {
        public int? ReportID { get; set; }
        public string ReportName { get; set; }
        public DateTime ReportDate { get; set; }

        public Report(int? reportID, string reportName, DateTime reportDate)
        {
            ReportID = reportID;
            ReportName = reportName;
            ReportDate = reportDate; //  = DateTime.Now; 
        }
        public Report(string reportName, DateTime reportDate)   
            : this(null, reportName, reportDate) { }
    }
}
