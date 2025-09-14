using RealEstateProperties.Domain.Mongo.SeedWork.Collections.Auth;

namespace RealEstateProperties.Domain.Mongo.SeedWork.Collections;

class AuthCollection
{
  public static UserCollection Users => new();
}
