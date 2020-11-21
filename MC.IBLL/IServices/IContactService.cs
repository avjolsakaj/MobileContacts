using System.Collections.Generic;
using System.Threading.Tasks;
using MC.DTO;

namespace MC.IBLL.IServices
{
    public interface IContactService
    {
        Task<List<PersonDTO?>> GetPersons(string? filterValue, string orderBy, bool orderAsc);
    }
}
