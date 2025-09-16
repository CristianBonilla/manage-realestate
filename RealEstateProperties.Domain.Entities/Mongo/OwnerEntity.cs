using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealEstateProperties.Domain.Entities.Mongo;

public class OwnerEntity : OwnerPhoto
{
  [BsonId]
  public ObjectId OwnerId { get; set; }
  public required string Name { get; set; }
  public required string Address { get; set; }
  public required DateTimeOffset Birthday { get; set; }
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
  public ulong Version { get; set; }
}

public abstract class OwnerPhoto
{
  public byte[]? Photo { get; set; } = null;
  public string? PhotoName { get; set; } = null;
}
