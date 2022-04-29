using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class Responsible
    {
        #region // Properties

        public int? RespinsilbeID { get; set; }
        public string Responsiblename { get; set; }


        #endregion

        #region // Constructors
        public Responsible(int? respinsilbeID, string responsiblename)
        {
            RespinsilbeID = respinsilbeID;
            Responsiblename = responsiblename;
        }
        public Responsible(string responsiblename) 
            : this(null, responsiblename) { }

        #endregion

    }
}
