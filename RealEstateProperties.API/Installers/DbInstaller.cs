using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using RealEstateProperties.API.Options;
using RealEstateProperties.API.Utils;
using RealEstateProperties.Contracts.Enums;
using RealEstateProperties.Domain.Helpers;
using RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties;

namespace RealEstateProperties.API.Installers;

class DbInstaller : IInstaller
{
  public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
  {
    string connectionString = GetConnectionString(configuration);
    var (client, database) = GetMongoConfig(connectionString, services, configuration);
    services.AddSingleton<IMongoClient>(client);
    services.AddSingleton(database);
    services.AddDbContext<RealEstatePropertiesContext>((provider, options) =>
    {
      options.UseMongoDB(client, database.DatabaseNamespace.DatabaseName)
        .LogTo(Console.WriteLine);
    });
  }

  private static (MongoClient Client, IMongoDatabase Database) GetMongoConfig(string connectionString, IServiceCollection services, IConfiguration configuration)
  {
    IConfigurationSection mongoSection = configuration.GetSection(nameof(MongoOptions));
    services.Configure<MongoOptions>(mongoSection);
    MongoOptions mongoOptions = mongoSection.Get<MongoOptions>()!;
    MongoUrl url = new(connectionString);
    MongoClient client = new(url);
    IMongoDatabase database = client.GetDatabase(mongoOptions.DatabaseName);

    return (client, database);
  }

  private static string GetConnectionString(IConfiguration configuration)
  {
    string connectionStringKey = ApiConfigKeys.GetConnectionKeyFromProcessType();
    string connectionString = configuration.GetConnectionString(connectionStringKey)
      ?? throw new InvalidOperationException($"Connection string \"{connectionStringKey}\" not established");
    if (ApiConfigKeys.ProcessType == ProcessTypes.Local)
      DirectoryConfigHelper.SetConnectionStringFullPathFromDataDirectory(ref connectionString);

    return connectionString;
  }
}
