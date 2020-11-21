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

        public ContactDTO? Convert(Contact? model)
        {
            return model == null
                ? null
                : new ContactDTO
                {
                    Id = model.Id,
                    Email = model.Email,
                    Number = model.Number,
                    ContactType = _contactTypeMapper.ConvertToString(model.ContactType)
                };
        }
    }
}
