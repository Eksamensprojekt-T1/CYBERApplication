using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class Illustration
    {
        #region // Propertys
        public int? IllustrationID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        #endregion
        #region // Constructors
        public Illustration(int? illustrationID, string fileName, string filePath)
        {
            IllustrationID = illustrationID;
            FileName = fileName;
            FilePath = filePath;
        }

        public Illustration(string fileName, string filePath)
            :this(null,  fileName,  filePath) { }
        #endregion
    }
}
