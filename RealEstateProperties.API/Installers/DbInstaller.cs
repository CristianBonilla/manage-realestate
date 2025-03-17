using Microsoft.EntityFrameworkCore;
using RealEstateProperties.API.Utils;
using RealEstateProperties.Domain.Helpers;
using RealEstateProperties.Infrastructure.Contexts.RealEstateProperties;

namespace RealEstateProperties.API.Installers;

class DbInstaller : IInstaller
{
  public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
  {
    string connectionString = GetConnectionString(configuration, ApiConfigKeys.IsLocalDbPlatform switch
    {
      true => ApiConfigKeys.LocalDbConnection,
      _ => ApiConfigKeys.DefaultDbConnection
    });
    services.AddDbContextPool<RealEstatePropertiesContext>(options => options.UseSqlServer(connectionString));
  }

  private static string GetConnectionString(IConfiguration configuration, string connectionStringKey)
  {
    string connectionString = configuration.GetConnectionString(connectionStringKey)
      ?? throw new InvalidOperationException($"Connection string \"{connectionStringKey}\" not established");
    if (ApiConfigKeys.IsLocalDbPlatform)
      DirectoryConfigHelper.SetConnectionStringFullPathFromDataDirectory(ref connectionString);

    return connectionString;
  }
}
