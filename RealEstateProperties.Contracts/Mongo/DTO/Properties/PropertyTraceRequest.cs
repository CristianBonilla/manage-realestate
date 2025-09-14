using MongoDB.Bson;

namespace RealEstateProperties.Contracts.Mongo.DTO.Properties;

public class PropertyTraceRequest
{
  public required ObjectId PropertyId { get; set; }
  public required string Name { get; set; }
  public required decimal Value { get; set; }
  public required decimal Tax { get; set; }
  public required DateTimeOffset DateSale { get; set; }
}
