using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuinsnessLogic.Models;

namespace BuinsnessLogic.Persistence
{
    public class QuestionRepository : IRepository<Question>
    {
        public int? Add(Question entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? entityID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public Question GetByID(int? entityID)
        {
            throw new NotImplementedException();
        }

        public void Update(Question entity)
        {
            throw new NotImplementedException();
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
