namespace RealEstateProperties.Contracts.Mongo.DTO.Properties;

public class PropertyResponse
{
  public string PropertyId { get; set; } = null!;
  public required string OwnerId { get; set; }
  public required string Name { get; set; }
  public required string Address { get; set; }
  public required decimal Price { get; set; }
  public int CodeInternal { get; set; }
  public required int Year { get; set; }
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
  public required IEnumerable<PropertyTraceResponse?> PropertyTraces { get; set; }
}
