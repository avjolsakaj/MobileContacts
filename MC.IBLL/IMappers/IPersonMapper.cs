using MC.DTO;
using MC.ENTITY.Models.DBO;

namespace MC.IBLL.IMappers
{
    public interface IPersonMapper
    {
        PersonDTO? Convert(Person? model);
    }
}
