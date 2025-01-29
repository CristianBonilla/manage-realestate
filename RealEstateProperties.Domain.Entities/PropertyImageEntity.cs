namespace RealEstateProperties.Domain.Entities
{
  public class PropertyImageEntity
  {
    public Guid PropertyImageId { get; set; }
    public Guid PropertyId { get; set; }
    public byte[] File { get; set; } = null!;
    public bool Enabled { get; set; }
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
    public PropertyEntity Property { get; set; } = null!;
  }
}
