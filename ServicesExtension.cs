
using System.Reflection;
using FirstAPI.Infrastructure.Persistence;

namespace FirstAPI
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(g => g.RegisterServicesFromAssemblies(
                AppDomain.CurrentDomain.GetAssemblies()));

            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
