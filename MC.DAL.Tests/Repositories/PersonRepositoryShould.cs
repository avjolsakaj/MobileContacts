using MC.DAL.Context;
using MC.DAL.Repositories;
using MC.ENTITY.Models.DBO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

namespace MC.DAL.Tests.Repositories
{
    public class TestRepositoryShould
    {
        [Fact]
        public async void GetTest()
        {
            var options = new DbContextOptionsBuilder<MCContext>()
                .UseInMemoryDatabase("MC")
                .Options;

            // Insert seed data into the database using one instance of the context
            await using (var context = new MCContext(options))
            {
                await context.Person.AddRangeAsync(new List<Person>
                {
                    new Person {Id = 1, FirstName = "Unit Test 1"},
                    new Person {Id = 2, FirstName = "Unit Test 2"},
                    new Person {Id = 3, FirstName = "Unit Test 3"}
                }).ConfigureAwait(false);

                _ = await context.SaveChangesAsync().ConfigureAwait(false);
            }

            // Use a clean instance of the context to run the test
            await using (var context = new MCContext(options))
            {
                var sut = new PersonRepository(context);

                var result = await sut.GetPersons("", "ID", true).ConfigureAwait(false);

                Assert.Equal(3, result.Count);
            }
        }
    }
}
