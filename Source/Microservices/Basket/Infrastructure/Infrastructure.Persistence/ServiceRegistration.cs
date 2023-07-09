using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositiories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            
                services.AddDbContext<ApplicationDbContext>(options =>
                    options
                        .UseInMemoryDatabase("ApplicationDb"));
            

            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IOrderRepositoryAsync, OrderRepositoryAsync>();
            services.AddTransient<IOrderItemRepositoryAsync, OrderItemRepositoryAsync>();
            #endregion
        }
    }
}
