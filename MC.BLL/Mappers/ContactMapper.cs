using MC.DTO;
using MC.ENTITY.Models.DBO;
using MC.IBLL.IMappers;

namespace MC.BLL.Mappers
{
    public class ContactMapper : IContactMapper
    {
        private readonly IContactTypeMapper _contactTypeMapper;

        public ContactMapper(IContactTypeMapper contactTypeMapper)
        {
            _contactTypeMapper = contactTypeMapper;
        }

        public ContactDetailsDTO? Convert(Contact? model)
        {
            return model == null
                ? null
                : new ContactDetailsDTO
                {
                    Id = model.Id,
                    Email = model.Email,
                    Number = model.Number,
                    ContactType = _contactTypeMapper.ConvertToString(model.ContactType)
                };
        }

        public Contact? Convert(EditContactDTO? model, int personId)
        {
            return model == null
                ? null
                : new Contact
                {
                    Id = model.Id,
                    Email = model.Email,
                    Number = model.Number,
                    ContactTypeId = model.ContactTypeId,
                    PersonId = personId
                };
        }

        public Contact? Convert(CreateContactDTO? model)
        {
            return model == null
                ? null
                : new Contact
                {
                    Email = model.Email,
                    Number = model.Number,
                    ContactTypeId = model.ContactTypeId
                };
        }

        public Contact? Convert(CreateContactDTO model, int personId)
        {
            return model == null
                ? null
                : new Contact
                {
                    Email = model.Email,
                    Number = model.Number,
                    ContactTypeId = model.ContactTypeId,
                    PersonId = personId
                };
        }
    }
}