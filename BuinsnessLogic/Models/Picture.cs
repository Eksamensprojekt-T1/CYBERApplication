namespace BuinsnessLogic.Models
{
    public class Picture
    {
        #region // Properties

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
