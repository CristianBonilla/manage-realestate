using MongoDB.Bson;

namespace RealEstateProperties.Domain.Entities.Mongo;

public class PropertyImageEntity : PropertyImage
{
  public ObjectId PropertyImageId { get; set; }
  public required ObjectId PropertyId { get; set; }
  public required bool Enabled { get; set; }
  public DateTimeOffset Created { get; set; }
}

public abstract class PropertyImage
{
  public required byte[] Image { get; set; }
  public required string ImageName { get; set; }
}
