using MC.DTO;
using MC.ENTITY.Models.DBO;
using MC.IBLL.IMappers;

namespace MC.BLL.Mappers
{
    public class ContactTypeMapper : IContactTypeMapper
    {
        public ContactTypeDTO? Convert(ContactType? model)
        {
            return model == null
                ? null
                : new ContactTypeDTO
                {
                    Id = model.Id,
                    Value = model.Value
                };
        }

        public string? ConvertToString(ContactType? model)
        {
            return model?.Value;
        }
    }
}
