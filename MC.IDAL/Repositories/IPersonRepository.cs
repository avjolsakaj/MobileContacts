using MC.ENTITY.Models.DBO;
using MC.IDAL.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MC.IDAL.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<List<Person>> GetPersons(string? filterValue, string orderBy, bool orderAsc);
    }
}
