using Microsoft.EntityFrameworkCore;
using RealEstateProperties.Contracts.Mongo.SeedData;
using RealEstateProperties.Infrastructure.Extensions;
using RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties.Config;
using RealEstateProperties.Infrastructure.Mongo.Extensions;

namespace RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties;

public class RealEstatePropertiesContext : DbContext
{
  readonly ISeedData _seedData;

  public RealEstatePropertiesContext(DbContextOptions<RealEstatePropertiesContext> options, ISeedData seedData) : base(options)
  {
    Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;
    _seedData = seedData;
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyEntityTypeConfig(_seedData, typeof(UserConfig));
    builder.ApplyEntityTypeConfig(_seedData,
      typeof(OwnerConfig),
      typeof(PropertyConfig),
      typeof(PropertyImageConfig),
      typeof(PropertyTraceConfig)
    );
  }
}
