using RealEstateProperties.Contracts.SeedData;
using RealEstateProperties.Domain.Entities.Mongo.Auth;

namespace RealEstateProperties.Contracts.Mongo.SeedData;

public class SeedAuthData
{
  public required SeedDataCollection<UserEntity> Users { get; set; }
}
