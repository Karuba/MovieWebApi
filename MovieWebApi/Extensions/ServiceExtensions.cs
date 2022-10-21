using LoggerService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Infrastructure.Business;
using MovieWebApi.Infrastructure.Data;
using MovieWebApi.Infrastructure.Data.Repositories;
using MovieWebApi.Infrastructure.Migr.SqlServer;
using MovieWebApi.Services.Interfaces;

namespace MovieWebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureDatabaseContext(this IServiceCollection services,
            IConfiguration configuration) =>
            //services.AddDbContext<RepositoryContext>(options =>
            //        options.UseSqlServer(configuration.GetConnectionString("SqlServer"), b =>
            //            b.MigrationsAssembly("MovieWebApi.Infrastructure.Migr.SqlServer")));
            ConnectionExtension.ConfigureDatabaseContext(services, configuration);
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureLoggerServices(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();
        //public static void ConfigureExceptionHandlerMiddleware(this IServiceCollection services) =>
        //    services.AddTransient<ExceptionHandlingMiddleware>();
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 2;
                o.User.RequireUniqueEmail = true;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<RepositoryContext>()
                    .AddDefaultTokenProviders();
        }
    }
}
