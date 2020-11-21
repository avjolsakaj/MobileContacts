using MC.DTO;
using MC.ENTITY.Models.DBO;

namespace MC.IBLL.IMappers
{
    public interface ITestMapper
    {
        TestDTO? Convert(Test? model);
    }
}
