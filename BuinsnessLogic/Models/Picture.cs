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
        public Byte[] PictureBitmap { get; set; }
        #endregion

        #region // Constructors
        public Picture(int? pictureID, Byte[] pictureBitmap)
        {
            PictureID = pictureID;
            PictureBitmap = pictureBitmap;
        }

        public Picture(Byte[] pictureBitmap) :this(null, pictureBitmap) { }
        #endregion
    }
}
