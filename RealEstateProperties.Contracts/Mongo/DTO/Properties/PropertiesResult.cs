using RealEstateProperties.Contracts.Mongo.DTO.Owner;

namespace RealEstateProperties.Contracts.Mongo.DTO.Properties;

public class PropertiesResult
{
  public required OwnerResponse Owner { get; set; }
  public required IEnumerable<PropertyResponse?> Properties { get; set; }
}
