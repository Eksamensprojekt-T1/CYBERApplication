using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class Illustration
    {
        #region // Properties

        public int? IllustationID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        #endregion

        #region // Constructors
        public Illustration(int? illustationID, string fileName, string filePath)
        {
            IllustationID = illustationID;
            FileName = fileName;
            FilePath = filePath;
        }

        public Illustration(string fileName, string filePath) 
            : this (null, fileName, filePath) { }

        #endregion

    }
}
