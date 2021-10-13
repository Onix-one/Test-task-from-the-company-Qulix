using Microsoft.Extensions.DependencyInjection;
using ProjectZ.BLL.Models;
using ProjectZ.DAL.ADO.NET.Repositories;
using ProjectZ.DAL.Interfaces;

namespace ProjectZ.Extensions
{
    public static class ServiceEntitiesRepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Company>, SqlCompanyRepository>();
            services.AddScoped<IRepository<Employee>, SqlEmployeeRepository>();

            return services;
        }
        
    }
}
