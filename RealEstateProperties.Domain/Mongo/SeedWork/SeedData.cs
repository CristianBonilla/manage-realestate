using RealEstateProperties.Contracts.Mongo.SeedData;
using RealEstateProperties.Domain.Mongo.SeedWork.Collections;

namespace RealEstateProperties.Domain.Mongo.SeedWork;

public class SeedData : ISeedData
{
  public SeedAuthData Auth => new()
  {
    Users = AuthCollection.Users
  };

  public SeedRealEstatePropertiesData RealEstateProperties => new()
  {
    Owners = RealEstatePropertiesCollection.Owners,
    Properties = RealEstatePropertiesCollection.Properties,
    PropertyImages = RealEstatePropertiesCollection.PropertyImages,
    PropertyTraces = RealEstatePropertiesCollection.PropertyTraces
  };
}
