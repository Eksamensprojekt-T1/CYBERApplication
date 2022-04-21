using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class Maincategory
    {
        #region // Properties

        public int? MaincategoryID { get; set; }

        public string MaincategoryName { get; set; }

        #endregion

        #region // Constructors

        public Maincategory(int? maincategoryID, string maincategoryName)
        {
            MaincategoryID = maincategoryID;
            MaincategoryName = maincategoryName;
        }

        public Maincategory(string maincategoryName)
            : this (null, maincategoryName) { }

        #endregion
    }
}
