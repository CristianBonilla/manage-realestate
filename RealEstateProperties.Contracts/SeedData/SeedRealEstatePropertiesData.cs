using RealEstateProperties.Domain.Entities;

namespace RealEstateProperties.Contracts.SeedData;

public class SeedRealEstatePropertiesData
{
  public required SeedDataCollection<OwnerEntity> Owners { get; set; }
  public required SeedDataCollection<PropertyEntity> Properties { get; set; }
  public required SeedDataCollection<PropertyImageEntity> PropertyImages { get; set; }
  public required SeedDataCollection<PropertyTraceEntity> PropertyTraces { get; set; }
}
