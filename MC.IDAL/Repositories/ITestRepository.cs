using MC.ENTITY.Models.DBO;
using MC.IDAL.Repositories.Base;
using System.Threading.Tasks;

namespace MC.IDAL.Repositories
{
    public interface ITestRepository : IRepository<Test>
    {
        //Read
        Task<Test> GetFirst();
    }
}
