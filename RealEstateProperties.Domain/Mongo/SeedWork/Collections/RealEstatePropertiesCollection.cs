using RealEstateProperties.Domain.Mongo.SeedWork.Collections.RealEstateProperties;

namespace RealEstateProperties.Domain.Mongo.SeedWork.Collections;

class RealEstatePropertiesCollection
{
  public static OwnerCollection Owners => new();
  public static PropertyCollection Properties => new();
  public static PropertyImageCollection PropertyImages => new();
  public static PropertyTraceCollection PropertyTraces => new();
}
