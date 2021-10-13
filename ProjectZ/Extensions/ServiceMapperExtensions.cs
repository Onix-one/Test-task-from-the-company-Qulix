using Microsoft.Extensions.DependencyInjection;
using ProjectZ.BLL.Models;
using ProjectZ.DAL.ADO.NET.Mapper;
using ProjectZ.DAL.ADO.NET.Repositories;
using ProjectZ.DAL.Interfaces;
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
