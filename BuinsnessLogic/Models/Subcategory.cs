using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class SubCategory
    {
        #region // Properties

        public int? SubCategoryID { get; set; }

        public string SubCategoryName { get; set; }

        public MainCategory category { get; set; }

        #endregion

        #region // Constructors
        public SubCategory(int? subCategoryID, string subCategoryName)
        {
            SubCategoryID = subCategoryID;
            SubCategoryName = subCategoryName;
        }

        public SubCategory(string subcategoryName)
            : this (null, subcategoryName) { }

        #endregion
    }
}
