using MC.DTO;
using MC.ENTITY.Models.DBO;

namespace MC.IBLL.IMappers
{
    public interface IContactMapper
    {
        ContactDetailsDTO? Convert(Contact? model);

        Contact? Convert(EditContactDTO? model, int personId);

        Contact? Convert(CreateContactDTO? model);

        Contact? Convert(CreateContactDTO x, int personId);
    }
}
