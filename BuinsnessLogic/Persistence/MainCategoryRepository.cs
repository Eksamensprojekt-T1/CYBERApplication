using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuinsnessLogic.Models;

namespace BuinsnessLogic.Persistence
{
    public class MainCategoryRepository : IRepository<Category>
    {
        public int? Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? entityID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetByID(int? entityID)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
        private void loadAllEntitys()
        {
            throw new NotImplementedException();
        }
    }
}
