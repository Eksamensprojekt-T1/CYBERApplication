using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuinsnessLogic.Models;

namespace BuinsnessLogic.Persistence
{
    public class PictureRepository : IRepository<Picture>
    {
        public List<Picture> PictureList { get; set; }

        private string connectionString;
        
        public PictureRepository(string connectionString)
        {
            this.connectionString = connectionString;
            loadAllEntitys();
            PictureList = new List<Picture>();
        }

        public int? Add(Picture picture)
        {
            int? result = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string table = "PICTURE";
                string coloumns = "PICTURE.PictureName, PICTURE.PicturePath";
                string values = "@PictureName, @PicturePath";
                string commandText =
                    $"INSERT INTO {table} ({coloumns})" +
                    $"VALUES ({values})" +
                    $"SELECT @@IDENTITY";

                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.Parameters.Add("@PictureName", SqlDbType.NVarChar).Value = picture.PictureName;
                    cmd.Parameters.Add("@PicturePath", SqlDbType.NVarChar).Value = picture.PicturePath;
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

        public Picture GetByID(int? entityID)
        {
            throw new NotImplementedException();
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
                string values = "PICTURE.PictureID, PICTURE.PictureName, PICTURE.PicturePath";
                string CommandText = $"SELECT {values} FROM {table}";

                con.Open();
                SqlCommand sQLCommand = new(CommandText, con);
                using (SqlDataReader reader = sQLCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int? pictureID = int.Parse(reader["PictureID"].ToString());
                        string pictureName = reader["PictureName"].ToString();
                        string picturePath = reader["PicturePath"].ToString();

                        PictureList.Add(new Picture(pictureID, pictureName, picturePath));
                    }
                }

            }
        }

    }
}
