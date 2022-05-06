using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuinsnessLogic.Models;

namespace BuinsnessLogic.Persistence
{
    public class ScreeningRepository : IRepository<Screening>
    {
        public List<Screening> Screenings { get; set; }
        private string connectionString;

        public ScreeningRepository(string connectionString)
        {
            Screenings = new();
            this.connectionString = connectionString;
        }

        public int? Add(Screening screening)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? screeningID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Screening> GetAll()
        {
            throw new NotImplementedException();
        }

        public Screening GetByID(int? screeningID)
        {
            throw new NotImplementedException();
        }

        public void Update(Screening screening)
        {
            throw new NotImplementedException();
        }
    }
}
