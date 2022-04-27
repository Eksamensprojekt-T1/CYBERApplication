using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class MainCategory
    {
        #region // Properties

        public int? MainCategoryID { get; set; }

        public string MainCategoryName { get; set; }

        #endregion

        #region // Constructors

        public MainCategory(int? mainCategoryID, string mainCategoryName)
        {
            MainCategoryID = mainCategoryID;
            MainCategoryName = mainCategoryName;
        }

        public MainCategory(string mainCategoryName)
            : this (null, mainCategoryName) { }

        #endregion
    }
}
