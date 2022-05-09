using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuinsnessLogic.Models;

namespace BuinsnessLogic.Persistence
{
    public class PictureRepository : IRepository<Picture>
    {
        public List<Picture> PictureList { get; set; } = new List<Picture>();

        private string connectionString;
        
        public PictureRepository(string connectionString)
        {
            this.connectionString = connectionString;
            loadAllEntitys();
        }

        public int? Add(Picture picture)
        {
            int? result = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string table = "PICTURE";
                string coloumns = "PICTURE.PictureBitmap";
                string values = "@PictureBitmap";
                string commandText =
                    $"INSERT INTO {table} ({coloumns})" +
                    $"VALUES ({values})" +
                    $"SELECT @@IDENTITY";

                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.Parameters.Add("@PictureBitmap", SqlDbType.VarBinary).Value = picture.PictureBitmap;
                    picture.PictureID = Convert.ToInt32(cmd.ExecuteScalar());
                    result = picture.PictureID;
                }

                PictureList.Add(picture);
            }

              return result;
        }

        public void Delete(int? entityID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Picture> GetAll()
        {
            return PictureList;
        }

        public Picture GetByID(int? pictureID)
        {
            Picture result = null;

            foreach (Picture picture in PictureList)
            {
                if (picture.PictureID.Equals(pictureID))
                {
                    result = picture;
                    break;
                }
            }
            return result;
        }

        public void Update(Picture entity)
        {
            throw new NotImplementedException();
        }
        private void loadAllEntitys()
        {
            using (SqlConnection con = new(connectionString))
            {
                string table = "PICTURE";
                string values = "PICTURE.PictureID, PICTURE.PictureBitmap";
                string CommandText = $"SELECT {values} FROM {table}";

                con.Open();
                SqlCommand sQLCommand = new(CommandText, con);
                using (SqlDataReader reader = sQLCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int? pictureID = int.Parse(reader["PictureID"].ToString());
                        Byte[] pictureBitmap = (Byte[])reader["PictureBitmap"];

                        PictureList.Add(new Picture(pictureID, pictureBitmap));
                    }
                }

            }
        }

    }
}
