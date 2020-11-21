using System.Collections.Generic;
using System.Threading.Tasks;
using MC.DTO;

namespace MC.IBLL.IServices
{
    public interface IContactService
    {
        Task<List<PersonDetailsDTO?>> GetPersons(string? filterValue, string orderBy, bool orderAsc);

        Task<PersonDetailsDTO?> CreatePerson(CreatePersonDTO request);

        Task<PersonDetailsDTO?> CreateContact(List<CreateContactDTO> request, int personId);

        Task<PersonDetailsDTO?> UpdatePerson(EditPersonDTO request);

        Task<PersonDetailsDTO?> UpdateContact(List<EditContactDTO> request, int personId);

        Task<bool> DeletePerson(int id);

        Task<bool> DeleteContact(List<int> ids);

        Task<List<ContactTypeDTO?>?> GetContactTypes();
    }
}
