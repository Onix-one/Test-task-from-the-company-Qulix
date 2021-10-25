using Microsoft.Extensions.DependencyInjection;
using ProjectZ.DAL.Dapper.Mapper;
using ProjectZ.Mapper;

namespace ProjectZ.Extensions
{
    public static class ServiceMapperExtensions
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddScoped<CustomSqlMapper, CustomSqlMapper>();
            services.AddScoped<CustomViewModelMapper, CustomViewModelMapper>();

            return services;
        }
        
    }
}
