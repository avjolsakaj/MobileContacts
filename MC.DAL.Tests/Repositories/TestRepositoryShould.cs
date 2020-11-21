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
                await context.Test.AddRangeAsync(new List<Test>
                {
                    new Test {Id = 1, Desc = "Movie 1"},
                    new Test {Id = 2, Desc = "Movie 2"},
                    new Test {Id = 3, Desc = "Movie 3"}
                }).ConfigureAwait(false);

                _ = await context.SaveChangesAsync().ConfigureAwait(false);
            }

            // Use a clean instance of the context to run the test
            await using (var context = new MCContext(options))
            {
                var sut = new TestRepository(context);

                var result = await sut.GetFirst().ConfigureAwait(false);

                Assert.Equal(1, result.Id);
            }
        }
    }
}
