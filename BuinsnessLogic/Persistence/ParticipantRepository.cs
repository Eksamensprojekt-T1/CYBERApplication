using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuinsnessLogic.Models;

namespace BuinsnessLogic.Persistence
{
    public class ParticipantRepository : IRepository<Participant>
    {
        public List<Participant> Participants { get; set; }
        private string connectionString;

        public ParticipantRepository(string connectionString)
        {
            Participants = new();
            this.connectionString = connectionString;
        }
        public int? Add(Participant participant)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? participantID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Participant GetByID(int? participantID)
        {
            throw new NotImplementedException();
        }

        public void Update(Participant participant)
        {
            throw new NotImplementedException();
        }
    }
}
