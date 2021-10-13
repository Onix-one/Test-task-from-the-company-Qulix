using Microsoft.Extensions.DependencyInjection;
using ProjectZ.BLL.Interfaces;
using ProjectZ.BLL.Models;
using ProjectZ.BLL.Services;

namespace ProjectZ.Extensions
{
    public static class ServiceEntitiesServicesExtensions
    {
        public static IServiceCollection AddEntitiesServices(this IServiceCollection services)
        {
            services.AddScoped<IEntityService<Company>, EntityService<Company>>();
            services.AddScoped<IEntityService<Employee>, EntityService<Employee>>();

            return services;
        }
    }
}
