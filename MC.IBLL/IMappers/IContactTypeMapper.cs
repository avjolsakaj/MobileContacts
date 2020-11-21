using MC.DTO;
using MC.ENTITY.Models.DBO;

namespace MC.IBLL.IMappers
{
    public interface IContactTypeMapper
    {
        ContactTypeDTO? Convert(ContactType? model);

        string? ConvertToString(ContactType? model);
    }
}
