using LoggerService;
using Microsoft.EntityFrameworkCore;
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
    }
}
