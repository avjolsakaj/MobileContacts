using MC.BLL.Mappers;
using MC.BLL.Services;
using MC.DAL.Repositories;
using MC.DAL.UOW;
using MC.IBLL.IMappers;
using MC.IBLL.IServices;
using MC.IDAL.Repositories;
using MC.IDAL.UOW;
using Microsoft.Extensions.DependencyInjection;

namespace MC.WebApi.Helpers
{
    /// <summary>
    /// Dependency Injection
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Inject all needed objects
        /// </summary>
        /// <param name="service"></param>
        public static void Inject(IServiceCollection service)
        {
            BllInject(service);
            DalInject(service);
        }

        private static void BllInject(IServiceCollection services)
        {
            // TODO: Add other services
            _ = services.AddScoped<ITestService, TestService>();

            // TODO: Add other mappers
            _ = services.AddScoped<ITestMapper, TestMapper>();
        }

        private static void DalInject(IServiceCollection services)
        {
            _ = services.AddScoped<IUnitOfWork, UnitOfWork>();
            _ = services.AddScoped<ITestRepository, TestRepository>();
        }
    }
}
