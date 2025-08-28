using Microsoft.EntityFrameworkCore;
using RealEstateProperties.API.Utils;
using RealEstateProperties.Infrastructure.Contexts.RealEstateProperties;

namespace RealEstateProperties.API.Installers;

class DbInstaller : IInstaller
{
  public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
  {
    string connectionStringName = ApiConfigKeys.RealEstatePropertiesConnection;
    string connectionString = configuration.GetConnectionString(connectionStringName)
      ?? throw new InvalidOperationException($"Connection string \"{connectionStringName}\" not established");
    services.AddDbContextPool<RealEstatePropertiesContext>(options => options.UseSqlServer(connectionString));
  }
}
