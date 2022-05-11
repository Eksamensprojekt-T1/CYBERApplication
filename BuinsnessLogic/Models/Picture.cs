using System;
using System.Collections.Generic;
using System.Drawing;
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
        #endregion

        #region // Constructors
        public Picture(int? pictureID, string pictureName)
        {
            PictureID = pictureID;
            PictureName = pictureName;
        }

        public Picture(string pictureName) :this(null, pictureName) { }
        #endregion
    }
}
