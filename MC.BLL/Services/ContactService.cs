using MC.DTO;
using MC.IBLL.IMappers;
using MC.IBLL.IServices;
using MC.IDAL.UOW;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MC.BLL.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public readonly IPersonMapper _personMapper;
        public readonly IContactMapper _contactMapper;
        public readonly IContactTypeMapper _contactTypeMapper;

        public ContactService(IUnitOfWork unitOfWork, IPersonMapper personMapper, IContactMapper contactMapper, IContactTypeMapper contactTypeMapper)
        {
            _unitOfWork = unitOfWork;

            _contactMapper = contactMapper;
            _contactTypeMapper = contactTypeMapper;
            _personMapper = personMapper;
        }

        public async Task<List<PersonDTO?>> GetPersons(string? filterValue, string orderBy, bool orderAsc)
        {
            var person = await _unitOfWork.PersonRepository.GetPersons(filterValue, orderBy.ToUpper(), orderAsc).ConfigureAwait(false);

            return person.ConvertAll(_personMapper.Convert);
        }
    }
}
