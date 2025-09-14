using MongoDB.Bson;

namespace RealEstateProperties.Contracts.Mongo.DTO.Owner;

public class OwnerResponse
{
  public ObjectId OwnerId { get; set; }
  public required string Name { get; set; }
  public required string Address { get; set; }
  public string? PhotoName { get; set; }
  public required DateTimeOffset Birthday { get; set; }
  public DateTimeOffset Created { get; set; }
}
