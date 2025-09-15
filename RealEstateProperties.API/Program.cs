using Autofac.Extensions.DependencyInjection;
using RealEstateProperties.API.Utils;
using RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties;

namespace RealEstateProperties.API;

public class Program
{
  public static async Task Main(string[] args)
  {
    IHost host = CreateHostBuilder(args).Build();
    await MongoDbConnectionSingleton.Start(host).Connect<RealEstatePropertiesContext>();
    await host.RunAsync();
  }

  private static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
      .UseServiceProviderFactory(new AutofacServiceProviderFactory())
      .ConfigureWebHostDefaults(builder =>
      {
        builder.UseStartup<Startup>();
      });
}
