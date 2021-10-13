using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProjectZ.BLL.Interfaces;
using ProjectZ.BLL.Models;
using ProjectZ.BLL.Services;
using ProjectZ.DAL.ADO.NET.Mapper;
using ProjectZ.DAL.ADO.NET.Repositories;
using ProjectZ.DAL.Interfaces;
using ProjectZ.Extensions;
using ProjectZ.Mapper;

namespace ProjectZ
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Инжектим строку подключения
            services.AddTransient<IDbConnection, SqlConnection>
                (connection => new SqlConnection(Configuration.GetConnectionString("msSql")));
            //Два метода расширения для DI
            services.AddRepositories();
            services.AddEntitiesServices();

            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
