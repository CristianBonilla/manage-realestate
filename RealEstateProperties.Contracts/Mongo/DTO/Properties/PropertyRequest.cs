namespace RealEstateProperties.Contracts.Mongo.DTO.Properties;

public class PropertyRequest
{
  public required string OwnerId { get; set; }
  public required string Name { get; set; }
  public required string Address { get; set; }
  public required decimal Price { get; set; }
  public required int Year { get; set; }
}
