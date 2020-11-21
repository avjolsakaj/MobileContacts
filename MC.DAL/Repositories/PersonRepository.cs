using System.Threading.Tasks;
using MC.DAL.Context;
using MC.ENTITY.Models.DBO;
using MC.IDAL.Repositories;
using MC.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MC.DAL.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(MCContext context) : base(context)
        {
        }

        public async Task<List<Person>> GetPersons(string? filterValue, string orderBy, bool orderAsc)
        {
            var person = _context.Person
                .Include(x => x.Contact)
                .ThenInclude(x => x.ContactType)
                .Where(x => string.IsNullOrEmpty(filterValue)
                            || x.FirstName.Contains(filterValue)
                            || x.LastName.Contains(filterValue)
                            || x.MiddleName.Contains(filterValue)
                            || x.Contact.Any(x => x.Number.Contains(filterValue)));

            person = orderBy switch
            {
                "FIRSTNAME" => orderAsc
                                    ? person.OrderBy(x => x.FirstName)
                                    : person.OrderByDescending(x => x.FirstName),
                "LASTNAME" => orderAsc
                                    ? person.OrderBy(x => x.LastName)
                                    : person.OrderByDescending(x => x.LastName),
                "MIDDLENAME" => orderAsc
                                    ? person.OrderBy(x => x.MiddleName)
                                    : person.OrderByDescending(x => x.MiddleName),
                _ => orderAsc
                                    ? person.OrderBy(x => x.Id)
                                    : person.OrderByDescending(x => x.Id),
            };

            return await person.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }
    }
}
