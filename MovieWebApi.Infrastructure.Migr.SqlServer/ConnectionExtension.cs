
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieWebApi.Infrastructure.Data;

namespace MovieWebApi.Infrastructure.Migr.SqlServer
{
    public static class ConnectionExtension
    {
        public static void ConfigureDatabaseContext(this IServiceCollection services,
            IConfiguration configuration) =>
                services.AddDbContext<RepositoryContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("SqlServer"), b =>
                        b.MigrationsAssembly("MovieWebApi.Infrastructure.Migr.SqlServer")));
    }
}