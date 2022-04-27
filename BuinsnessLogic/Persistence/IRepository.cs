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
        IEnumerable<T> GetAll();    // read
        T GetByID(int? entityID);
        int? Add(T entity);         // create
        void Update(T entity);      // update one entity from local storage into databse
        void Update();              // update whole list from databse into local storage
        void Delete(int? entityID);  // delete
    }
}
