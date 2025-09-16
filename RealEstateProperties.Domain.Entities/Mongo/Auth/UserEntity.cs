using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealEstateProperties.Domain.Entities.Mongo.Auth;

public class UserEntity
{
  [BsonId]
  public ObjectId UserId { get; set; }
  public required string DocumentNumber { get; set; }
  public required string Mobile { get; set; }
  public required string Username { get; set; }
  public required string Password { get; set; }
  public required string Email { get; set; }
  public required string Firstname { get; set; }
  public required string Lastname { get; set; }
  public bool IsActive { get; set; }
  public required byte[] Salt { get; set; }
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
  public ulong Version { get; set; }
}
