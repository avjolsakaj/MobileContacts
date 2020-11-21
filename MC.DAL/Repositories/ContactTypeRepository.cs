using MC.DAL.Context;
using MC.ENTITY.Models.DBO;
using MC.IDAL.Repositories;
using MC.DAL.Repositories.Base;

namespace MC.DAL.Repositories
{

    public class ContactTypeRepository : GenericRepository<ContactType>, IContactTypeRepository
    {
        public ContactTypeRepository(MCContext context) : base(context)
        {
        }
    }
}
