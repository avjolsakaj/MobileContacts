using MC.DTO;
using MC.ENTITY.Models.DBO;
using MC.IBLL.IMappers;
using System.Linq;

namespace MC.BLL.Mappers
{
    public class PersonMapper : IPersonMapper
    {
        private readonly IContactMapper _contactMapper;

        public PersonMapper(IContactMapper contactMapper)
        {
            _contactMapper = contactMapper;
        }

        public PersonDTO? Convert(Person? model)
        {
            if (model == null)
            {
                return null;
            }

            return new PersonDTO
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Contact = model.Contact.Select(_contactMapper.Convert).ToList()
            };
        }
    }
}
