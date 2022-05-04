﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class Category
    {
        #region // Properties

        public int? CategoryID { get; set; }

        public string CategoryName { get; set; }

        public List<Question> Questions { get; set; }

        #endregion

        #region // Constructors

        public Category(int? categoryID, string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            Questions = new List<Question>();
        }

        public Category(string CategoryName)
            : this (null, CategoryName) { }

        #endregion
    }
}
