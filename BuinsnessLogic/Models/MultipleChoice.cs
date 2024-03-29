﻿using System;
using System.Collections.Generic;

namespace BuinsnessLogic.Models
{
    public class MultipleChoice
    {
        #region // Properties

        public int? MCID { get; set; }
        public string MCName { get; set; }
        public DateTime DateOfCreation { get; set; }
        public List<Question> Questions { get; set; }

        #endregion

        #region // Constructors
        public MultipleChoice(int? mCID, string mCName, DateTime dateOfCreation, List<Question> questions)
        {
            MCID = mCID;
            MCName = mCName;
            DateOfCreation = dateOfCreation;
            Questions = questions;
        }

        public MultipleChoice(string mCName, DateTime dateOfCreation, List<Question> questions)
            : this(null, mCName, dateOfCreation, questions) { }

        #endregion
    }
}
