using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SusWarriors.Core.Interfaces.Data;
using SusWarriors.Infrastructure.Data;
using SusWarriors.Infrastructure.Options;

namespace SusWarriors.Infrastructure.Extensions;
public static class DatabaseServiceCollectionExtensions
{
  public static void ConfigureDb<T>(this IServiceCollection services, IConfiguration config)
    where T: DbContext
  {
    var dbSection = config.GetSection(nameof(DbOptions));
    DbOptions? dbOpts = null;
    if (dbSection.Exists())
    {
      dbOpts = new DbOptions();
      dbSection.Bind(dbOpts);
    }
    string? connectionStr = dbOpts is not null
      ? $"Server={dbOpts.Server},{dbOpts.Port};Initial Catalog={dbOpts.Database};User ID={dbOpts.User};Password={dbOpts.Password};TrustServerCertificate=True"
      : config.GetConnectionString("SqlServer");
    services.AddDbContext<T>(opts =>
      opts.UseSqlServer(connectionStr));
    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(CachedRepository<>));
    services.AddMemoryCache();
  }

  public static void BuildDatabase<T>(this IHost host) where T : DbContext
  {
    using IServiceScope scope = host.Services.CreateScope();
    scope.ServiceProvider.GetRequiredService<T>().Database.Migrate();
  }
}
