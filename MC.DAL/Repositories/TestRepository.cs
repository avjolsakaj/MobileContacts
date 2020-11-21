using System.Threading.Tasks;
using MC.DAL.Context;
using MC.ENTITY.Models.DBO;
using MC.IDAL.Repositories;
using MC.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace MC.DAL.Repositories
{
    public class TestRepository : GenericRepository<Test>, ITestRepository
    {
        public TestRepository(MCContext context) : base(context)
        {
        }

        public async Task<Test> GetFirst()
        {
            return await _context.Test.FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
