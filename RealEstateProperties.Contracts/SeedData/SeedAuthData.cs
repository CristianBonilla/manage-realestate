using RealEstateProperties.Domain.Entities.Auth;

namespace RealEstateProperties.Contracts.SeedData
{
  public class SeedAuthData
  {
    public required SeedDataCollection<UserEntity> Users { get; set; }
  }
}
