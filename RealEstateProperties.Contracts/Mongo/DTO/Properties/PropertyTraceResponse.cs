namespace RealEstateProperties.Contracts.Mongo.DTO.Properties;

public class PropertyTraceResponse
{
  public string PropertyTraceId { get; set; } = null!;
  public required string PropertyId { get; set; }
  public required string Name { get; set; }
  public required decimal Value { get; set; }
  public required decimal Tax { get; set; }
  public required DateTimeOffset DateSale { get; set; }
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
}
