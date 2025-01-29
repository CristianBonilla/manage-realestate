namespace RealEstateProperties.Domain.Entities
{
  public class PropertyTraceEntity
  {
    public Guid PropertyTraceId { get; set; }
    public Guid PropertyId { get; set; }
    public required string Name { get; set; }
    public required decimal Value { get; set; }
    public required decimal Tax { get; set; }
    public DateTimeOffset DateSale { get; set; }
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
    public PropertyEntity Property { get; set; } = null!;
  }
}
