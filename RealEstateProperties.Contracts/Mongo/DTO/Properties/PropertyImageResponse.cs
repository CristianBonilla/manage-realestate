namespace RealEstateProperties.Contracts.Mongo.DTO.Properties;

public class PropertyImageResponse
{
  public string PropertyImageId { get; set; } = null!;
  public required string PropertyId { get; set; }
  public required bool Enabled { get; set; }
  public required string ImageName { get; set; }
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
}
