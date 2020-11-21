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

        public PersonDetailsDTO? Convert(Person? model)
        {
            if (model == null)
            {
                return null;
            }

            return new PersonDetailsDTO
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Contacts = model.Contact.Select(_contactMapper.Convert).ToList()
            };
        }

        public Person? Convert(EditPersonDTO? model)
        {
            return model == null
                ? null
                : new Person
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName
                };
        }

        public Person? Convert(CreatePersonDTO? model)
        {
            if (model == null)
            {
                return null;
            }

            return new Person
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                Contact = model.Contacts?.ConvertAll(_contactMapper.Convert)
            };
        }
    }
}
