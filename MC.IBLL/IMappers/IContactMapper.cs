using MC.DTO;
using MC.ENTITY.Models.DBO;

namespace MC.IBLL.IMappers
{

    public interface IContactMapper
    {
        ContactDTO? Convert(Contact? model);
    }
}
