namespace RealEstateProperties.Contracts.SeedData
{
  public interface ISeedData
  {
    SeedAuthData Auth { get; }
    SeedRealEstatePropertiesData RealEstateProperties { get; }
  }
}
