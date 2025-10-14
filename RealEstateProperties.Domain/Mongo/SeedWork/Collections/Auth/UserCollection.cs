using RealEstateProperties.Contracts.SeedData;
using RealEstateProperties.Domain.Entities.Mongo.Auth;

namespace RealEstateProperties.Domain.Mongo.SeedWork.Collections.Auth;

class UserCollection : SeedDataCollection<UserEntity>
{
  const string PASSWORD = "oO63zcP14ylquh+FDz/NdI3v2Zltfk2p4gmLcZ6bmmwcwCJlEMjIH95egAt/BGZiWjKVTkblXoQOuxv/OAFegw==";
  readonly byte[] _saltBytes = [160, 238, 183, 205, 195, 245, 227, 41, 106, 186, 31, 133, 15, 63, 205, 116, 141, 239, 217, 153, 109, 126, 77, 169, 226, 9, 139, 113, 158, 155, 154, 108];

  protected override UserEntity[] Collection => [
    new()
    {
      UserId = new("68ed98795e9a77cf7005834f"),
      DocumentNumber = "1023944678",
      Mobile = "+573163534451",
      Username = "chris__boni",
      Password = PASSWORD,
      Email = "cristian10camilo95@gmail.com",
      Firstname = "Cristian Camilo",
      Lastname = "Bonilla",
      IsActive = true,
      Salt = _saltBytes
    }
  ];
}
