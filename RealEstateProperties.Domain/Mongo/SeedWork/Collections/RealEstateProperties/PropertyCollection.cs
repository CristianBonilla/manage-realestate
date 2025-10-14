using RealEstateProperties.Contracts.SeedData;
using RealEstateProperties.Domain.Entities.Mongo;

namespace RealEstateProperties.Domain.Mongo.SeedWork.Collections.RealEstateProperties;

class PropertyCollection : SeedDataCollection<PropertyEntity>
{
  static readonly OwnerCollection _owners = RealEstatePropertiesCollection.Owners;

  protected override PropertyEntity[] Collection => [
    new()
    {
      PropertyId = new("68ed98a65e9a77cf70058350"),
      OwnerId = _owners[0].OwnerId,
      Name = "Headland Waters Mount Martha",
      Address = "6677 Schroeder Avenue",
      Price = 1358000000,
      CodeInternal = 34432111,
      Year = 2018,
      CreatedAt = new(2023, 1, 27, 11, 1, 26, TimeSpan.FromHours(3))
    },
    new()
    {
      PropertyId = new("68ed98a65e9a77cf70058351"),
      OwnerId = _owners[0].OwnerId,
      Name = "Luyary Jeddo",
      Address = "Moussaouidreef 8",
      Price = 1297566000,
      CodeInternal = 98801123,
      Year = 2021,
      CreatedAt = new(2023, 1, 27, 12, 5, 0, TimeSpan.FromHours(3))
    },
    new()
    {
      PropertyId = new("68ed98a65e9a77cf70058352"),
      OwnerId = _owners[0].OwnerId,
      Name = "Runneymede",
      Address = "8098 Yundt Mission",
      Price = 1188954000,
      CodeInternal = 11983367,
      Year = 2020,
      CreatedAt = new(2023, 1, 27, 18, 50, 0, TimeSpan.FromHours(3))
    },
    new()
    {
      PropertyId = new("68ed98a65e9a77cf70058353"),
      OwnerId = _owners[1].OwnerId,
      Name = "Zuburnano Up",
      Address = "701, avenue de Guilbert",
      Price = 1877544000,
      CodeInternal = 87711809,
      Year = 2021,
      CreatedAt = new(2023, 1, 28, 20, 0, 27, TimeSpan.FromHours(3))
    },
    new()
    {
      PropertyId = new("68ed98a65e9a77cf70058354"),
      OwnerId = _owners[1].OwnerId,
      Name = "The Kingfisher",
      Address = "193 Kshlerin Spring",
      Price = 1988411000,
      CodeInternal = 43309922,
      Year = 2020,
      CreatedAt = new(2023, 1, 28, 21, 16, 0, TimeSpan.FromHours(3))
    }
  ];
}
