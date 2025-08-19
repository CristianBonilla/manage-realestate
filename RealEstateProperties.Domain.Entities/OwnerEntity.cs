namespace RealEstateProperties.Domain.Entities
{
  public class OwnerEntity
  {
    public Guid OwnerId { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public byte[]? Photo { get; set; }
    public DateTimeOffset Birthday { get; set; }
    public DateTimeOffset Created { get; set; }
    public byte[] Version { get; set; } = null!;
    public ICollection<PropertyEntity> Properties { get; set; } = [];
  }
}
