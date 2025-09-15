using MongoDB.Bson;

namespace RealEstateProperties.Domain.Entities.Mongo;

public class OwnerEntity
{
  public ObjectId OwnerId { get; set; }
  public required string Name { get; set; }
  public required string Address { get; set; }
  public byte[]? Photo { get; set; } = null;
  public string? PhotoName { get; set; } = null;
  public required DateTimeOffset Birthday { get; set; }
  public DateTimeOffset Created { get; set; }
}
