﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class MultipleChoice
    {
        public int? MCID { get; set; }
        public string MCName { get; set; }
        public DateTime DateOfCreation { get; set; }

        public MultipleChoice(int? mCID, string mCName, DateTime dateOfCreation)
        {
            MCID = mCID;
            MCName = mCName;
            DateOfCreation = dateOfCreation;
        }

        public MultipleChoice(string mCName, DateTime dateOfCreation)
            : this(null, mCName, dateOfCreation) { }
    }
}