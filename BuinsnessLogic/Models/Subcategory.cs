using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class Subcategory
    {
        #region // Properties

        public int? SubcategoryID { get; set; }

        public string SubcategoryName { get; set; }

        #endregion

        #region // Constructors
        public Subcategory(int? subcategoryID, string subcategoryName)
        {
            SubcategoryID = subcategoryID;
            SubcategoryName = subcategoryName;
        }

        public Subcategory(string subcategoryName)
            : this (null, subcategoryName) { }

        #endregion
    }
}
