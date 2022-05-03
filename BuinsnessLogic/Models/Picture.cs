using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinsnessLogic.Models
{
    public class Picture
    {
        #region // Propertys
        public int? PictureID { get; set; }
        public string PictureName { get; set; }
        public string PicturePath { get; set; }
        #endregion

        #region // Constructors
        public Picture(int? pictureID, string pictureName, string picturePath)
        {
            PictureID = pictureID;
            PictureName = pictureName;
            PicturePath = picturePath;
        }

        public Picture(string pictureName, string picturePath)
            :this(null, pictureName, picturePath) { }
        #endregion
    }
}
