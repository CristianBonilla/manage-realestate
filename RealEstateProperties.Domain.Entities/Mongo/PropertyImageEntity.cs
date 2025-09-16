using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealEstateProperties.Domain.Entities.Mongo;

public class PropertyImageEntity : PropertyImage
{
  [BsonId]
  public ObjectId PropertyImageId { get; set; }
  public required ObjectId PropertyId { get; set; }
  public required bool Enabled { get; set; }
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
  public ulong Version { get; set; }
}

public abstract class PropertyImage
{
  public required byte[] Image { get; set; }
  public required string ImageName { get; set; }
}
