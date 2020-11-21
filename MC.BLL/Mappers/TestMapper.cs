using MC.DTO;
using MC.ENTITY.Models.DBO;
using MC.IBLL.IMappers;

namespace MC.BLL.Mappers
{
    public class TestMapper : ITestMapper
    {
        public TestDTO? Convert(Test? model)
        {
            if (model == null)
            {
                return null;
            }

            return new TestDTO
            {
                Id = model.Id
            };
        }
    }
}
