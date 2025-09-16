namespace RealEstateProperties.Contracts.Mongo.DTO.User;

public class UserResponse
{
  public string UserId { get; set; } = null!;
  public required string DocumentNumber { get; set; }
  public required string Mobile { get; set; }
  public required string Username { get; set; }
  public required string Email { get; set; }
  public required string Firstname { get; set; }
  public required string Lastname { get; set; }
  public bool IsActive { get; set; }
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
}
