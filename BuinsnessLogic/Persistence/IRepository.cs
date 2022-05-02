using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuinsnessLogic.Models;


namespace BuinsnessLogic.Persistence
{
    public interface IRepository<T>
    {
        int? Add(T entity);         // create
        IEnumerable<T> GetAll();    // read all
        T GetByID(int? entityID);   // read one
        void Update(T entity);      // update one entity
        void Delete(int? entityID); // delete
    }
}
