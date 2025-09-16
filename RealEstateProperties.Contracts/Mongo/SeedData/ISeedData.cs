namespace RealEstateProperties.Contracts.Mongo.SeedData;

public interface ISeedData
{
  SeedAuthData Auth { get; }
  SeedRealEstatePropertiesData RealEstateProperties { get; }
}
