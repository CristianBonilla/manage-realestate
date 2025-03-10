using Autofac.Extensions.DependencyInjection;
using RealEstateProperties.API.Utils;
using RealEstateProperties.Contracts.Enums;
using RealEstateProperties.Infrastructure.Contexts.RealEstateProperties;

namespace RealEstateProperties.API;

public class Program
{
  public static async Task Main(string[] args)
  {
    IHost host = CreateHostBuilder(args).Build();
    await DbConnectionSingleton.Start(host).Connect<RealEstatePropertiesContext>(DbConnectionTypes.Migration);
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
