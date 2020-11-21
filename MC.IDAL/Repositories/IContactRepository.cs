using MC.ENTITY.Models.DBO;
using MC.IDAL.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MC.IDAL.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        //Read
        Task<List<Contact>> GetByPersonAsync(int personId);

        Task<List<Contact>> GetByPersonAsync(string firstName, string lastName);
    }
}
