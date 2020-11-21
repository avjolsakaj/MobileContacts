using System.Threading.Tasks;
using MC.DTO;

namespace MC.IBLL.IServices
{
    public interface ITestService
    {
        Task<TestDTO?> Get();
    }
}
