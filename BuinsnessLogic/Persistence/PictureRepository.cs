using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Update(Picture entity)
        {
            throw new NotImplementedException();
        }
        private void loadAllEntitys()
        {
            throw new NotImplementedException();
        }

    }
}
