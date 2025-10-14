using RealEstateProperties.Contracts.SeedData;
using RealEstateProperties.Domain.Entities.Mongo;

namespace RealEstateProperties.Domain.Mongo.SeedWork.Collections.RealEstateProperties;

class PropertyTraceCollection : SeedDataCollection<PropertyTraceEntity>
{
  static readonly PropertyCollection _properties = RealEstatePropertiesCollection.Properties;

  protected override PropertyTraceEntity[] Collection => [
    new()
    {
      PropertyTraceId = new("68ed993c5e9a77cf70058364"),
      PropertyId = _properties[0].PropertyId,
      Name = "Headland Waters Mount Martha Trace",
      Value = 1058000000M,
      Tax = 5430000M,
      DateSale = new(2024, 2, 11, 21, 5, 19, TimeSpan.FromHours(3)),
      CreatedAt = new(2024, 2, 11, 0, 0, 0, TimeSpan.FromHours(3))
    },
    new()
    {
      PropertyTraceId = new("68ed993c5e9a77cf70058365"),
      PropertyId = _properties[1].PropertyId,
      Name = "Luyary Jeddo Trace",
      Value = 1117566000M,
      Tax = 6132000M,
      DateSale = new(2024, 5, 20, 8, 20, 0, TimeSpan.FromHours(3)),
      CreatedAt = new(2024, 5, 20, 0, 0, 0, TimeSpan.FromHours(3))
    },
    new()
    {
      PropertyTraceId = new("68ed993c5e9a77cf70058366"),
      PropertyId = _properties[2].PropertyId,
      Name = "Runneymede Trace",
      Value = 1008954000M,
      Tax = 5011000M,
      DateSale = new(2024, 12, 11, 10, 33, 8, TimeSpan.FromHours(3)),
      CreatedAt = new(2024, 12, 11, 0, 0, 0, TimeSpan.FromHours(3))
    },
    new()
    {
      PropertyTraceId = new("68ed993c5e9a77cf70058367"),
      PropertyId = _properties[3].PropertyId,
      Name = "Zuburnano Up Trace",
      Value = 1417844000M,
      Tax = 6234000M,
      DateSale = new(2024, 7, 25, 12, 7, 45, TimeSpan.FromHours(3)),
      CreatedAt = new(2024, 7, 25, 0, 0, 0, TimeSpan.FromHours(3))
    },
    new()
    {
      PropertyTraceId = new("68ed993c5e9a77cf70058368"),
      PropertyId = _properties[4].PropertyId,
      Name = "The Kingfisher Trace",
      Value = 1122910000M,
      Tax = 8950000M,
      DateSale = new(2024, 8, 22, 1, 2, 18, TimeSpan.FromHours(3)),
      CreatedAt = new(2024, 8, 22, 1, 2, 18, TimeSpan.FromHours(3))
    }
  ];
}
