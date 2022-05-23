using System.Collections.Generic;


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
