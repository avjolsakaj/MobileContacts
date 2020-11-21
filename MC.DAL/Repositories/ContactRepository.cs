using System.Threading.Tasks;
using MC.DAL.Context;
using MC.ENTITY.Models.DBO;
using MC.IDAL.Repositories;
using MC.DAL.Repositories.Base;
using System.Collections.Generic;

namespace MC.DAL.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(MCContext context) : base(context)
        {
        }

        public Task<List<Contact>> GetByPersonAsync(int personId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Contact>> GetByPersonAsync(string firstName, string lastName)
        {
            throw new System.NotImplementedException();
        }
    }
}
