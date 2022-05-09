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
        public Bitmap PictureBitmap { get; set; }
        #endregion

        #region // Constructors
        public Picture(int? pictureID, Bitmap pictureBitmap)
        {
            PictureID = pictureID;
            PictureBitmap = pictureBitmap;
        }

        public Picture(Bitmap pictureBitmap)
            :this(null, pictureBitmap) { }
        #endregion
    }
}
