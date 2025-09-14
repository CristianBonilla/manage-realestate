using MongoDB.Bson;
using RealEstateProperties.Contracts.SeedData;
using RealEstateProperties.Domain.Entities.Mongo;
using RealEstateProperties.Domain.SeedWork;

namespace RealEstateProperties.Domain.Mongo.SeedWork.Collections.RealEstateProperties;

class OwnerCollection : SeedDataCollection<OwnerEntity>
{
  protected override OwnerEntity[] Collection => [
    new()
    {
      OwnerId = ObjectId.GenerateNewId(),
      Name = "Cristian Camilo Bonilla",
      Address = "Cl. 139 # 94 - 90",
      Photo = SeedImagesData.OwnerPhotos[0],
      PhotoName = "69917363-3927-497a-9e2f-a2b783cf8222.png",
      Birthday = new(1995, 8, 11, 0, 0, 0, TimeSpan.FromHours(3)),
      Created = new(2023, 1, 27, 9, 32, 22, TimeSpan.FromHours(3))
    },
    new()
    {
      OwnerId = ObjectId.GenerateNewId(),
      Name = "Mayerlis Cordero",
      Address = "Cl. 169 # 20-57",
      Photo = SeedImagesData.OwnerPhotos[1],
      PhotoName = "ce860353-677d-480b-81e9-5a640a96851b.jpg",
      Birthday = new(2001, 9, 3, 0, 0, 0, TimeSpan.FromHours(3)),
      Created = new(2023, 1, 28, 13, 5, 18, TimeSpan.FromHours(3))
    }
  ];
}
