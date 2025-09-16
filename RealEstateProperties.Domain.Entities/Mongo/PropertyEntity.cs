using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealEstateProperties.Domain.Entities.Mongo;

public class PropertyEntity
{
  [BsonId]
  public ObjectId PropertyId { get; set; }
  public required ObjectId OwnerId { get; set; }
  public required string Name { get; set; }
  public required string Address { get; set; }
  public required decimal Price { get; set; }
  public int CodeInternal { get; set; }
  public required int Year { get; set; }
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
  public ulong Version { get; set; }
}
