using MC.DTO;
using MC.ENTITY.Models.DBO;

namespace MC.IBLL.IMappers
{
    public interface IPersonMapper
    {
        PersonDetailsDTO? Convert(Person? model);

        Person? Convert(EditPersonDTO? model);

        Person? Convert(CreatePersonDTO? model);
    }
}
