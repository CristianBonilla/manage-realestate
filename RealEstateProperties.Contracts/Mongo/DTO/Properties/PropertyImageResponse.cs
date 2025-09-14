using MongoDB.Bson;

namespace RealEstateProperties.Contracts.Mongo.DTO.Properties;

public class PropertyImageResponse
{
  public ObjectId PropertyImageId { get; set; }
  public required ObjectId PropertyId { get; set; }
  public required bool Enabled { get; set; }
  public required string ImageName { get; set; }
  public DateTimeOffset Created { get; set; }
}
