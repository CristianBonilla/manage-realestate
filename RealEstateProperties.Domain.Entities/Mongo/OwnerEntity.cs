using MongoDB.Bson;

namespace RealEstateProperties.Domain.Entities.Mongo;

public class OwnerEntity : OwnerPhoto
{
  public ObjectId OwnerId { get; set; }
  public required string Name { get; set; }
  public required string Address { get; set; }
  public required DateTimeOffset Birthday { get; set; }
  public DateTimeOffset Created { get; set; }
}
