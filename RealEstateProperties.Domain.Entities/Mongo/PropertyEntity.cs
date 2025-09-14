using MongoDB.Bson;

namespace RealEstateProperties.Domain.Entities.Mongo;

public class PropertyEntity
{
  public ObjectId PropertyId { get; set; }
  public required ObjectId OwnerId { get; set; }
  public required string Name { get; set; }
  public required string Address { get; set; }
  public required decimal Price { get; set; }
  public int CodeInternal { get; set; }
  public required int Year { get; set; }
  public DateTimeOffset Created { get; set; }
}
