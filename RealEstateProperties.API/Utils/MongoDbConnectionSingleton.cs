using MongoDB.Driver;
using MongoFramework;
using RealEstateProperties.Contracts.Mongo.SeedData;

namespace RealEstateProperties.API.Utils;

class MongoDbConnectionSingleton
{
  static Lazy<MongoDbConnectionSingleton>? _instance;
  readonly IHost _host;

  private MongoDbConnectionSingleton(IHost host) => _host = host;

  public static MongoDbConnectionSingleton Start(IHost host)
  {
    _instance ??= new(() => new(host));

    return _instance.Value;
  }

  public async Task Connect<TContext>() where TContext : MongoDbContext
  {
    var (scope, seedData) = GetContextScope<TContext>();
    try
    {
      await using (scope.ConfigureAwait(false))
      {
        await seedData.LoadAsync();
      }
      Console.WriteLine($"{typeof(TContext).Name} DB connection started successfully.");
    }
    catch (MongoConnectionException)
    {
      Console.WriteLine("Unhandled exception while DB connection.");

      throw;
    }
    catch (MongoException exception)
    {
      Console.WriteLine(exception.Message);
    }
  }

  private (AsyncServiceScope scope, ISeedData seedData) GetContextScope<TContext>() where TContext : MongoDbContext
  {
    AsyncServiceScope scope = _host.Services.CreateAsyncScope();
    ISeedData seedData = scope.ServiceProvider.GetRequiredService<ISeedData>();

    return (scope, seedData);
  }
}
