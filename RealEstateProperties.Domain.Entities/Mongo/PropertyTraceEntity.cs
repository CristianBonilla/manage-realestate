using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealEstateProperties.Domain.Entities.Mongo;

public class PropertyTraceEntity
{
  [BsonId]
  public ObjectId PropertyTraceId { get; set; }
  public required ObjectId PropertyId { get; set; }
  public required string Name { get; set; }
  public required decimal Value { get; set; }
  public required decimal Tax { get; set; }
  public required DateTimeOffset DateSale { get; set; }
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
  public ulong Version { get; set; }
}
