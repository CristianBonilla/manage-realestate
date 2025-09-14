using MongoDB.Bson;
using RealEstateProperties.Domain.Entities.Mongo.Auth;

namespace RealEstateProperties.Contracts.Mongo.Services;

public interface IAuthService
{
  Task<UserEntity> AddUser(UserEntity user);
  Task<bool> UserExists(string documentNumber, string email);
  IAsyncEnumerable<UserEntity> GetUsers();
  Task<UserEntity> FindUserById(ObjectId userId);
  Task<UserEntity> FindUserByUsernameOrEmail(string usernameOrEmail);
}
