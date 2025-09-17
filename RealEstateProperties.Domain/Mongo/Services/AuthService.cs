using System.Net;
using MongoDB.Bson;
using RealEstateProperties.Contracts.Exceptions;
using RealEstateProperties.Contracts.Mongo.Services;
using RealEstateProperties.Domain.Entities.Mongo.Auth;
using RealEstateProperties.Domain.Helpers;
using RealEstateProperties.Infrastructure.Mongo.Repositories.Auth.Interfaces;
using RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties.Interfaces;

namespace RealEstateProperties.Domain.Mongo.Services;

public class AuthService(IRealEstatePropertiesRepositoryContext context, IUserRepository userRepository) : IAuthService
{
  readonly IRealEstatePropertiesRepositoryContext _context = context;
  readonly IUserRepository _userRepository = userRepository;

  public async Task<UserEntity> AddUser(UserEntity user)
  {
    var (password, salt) = HashPasswordHelper.Create(user.Password);
    user.Password = password;
    user.Salt = salt;
    user.IsActive = true;
    UserEntity addedUser = _userRepository.Create(user);
    _ = await _context.SaveAsync();

    return addedUser;
  }

  public async Task<bool> UserExists(UserEntity userRequired)
    => await GetUsers()
        .AnyAsync(user => 
          StringCommonHelper.IsStringEquivalent(user.DocumentNumber, userRequired.DocumentNumber) || 
          StringCommonHelper.IsStringEquivalent(user.Username, userRequired.Username) ||
          StringCommonHelper.IsStringEquivalent(user.Email, userRequired.Email) ||
          StringCommonHelper.IsStringEquivalent(user.Mobile, userRequired.Mobile));

  public IAsyncEnumerable<UserEntity> GetUsers()
  {
    var users = _userRepository.GetAll(users => users.OrderBy(order => order.Firstname)
      .ThenBy(order => order.Username))
      .ToAsyncEnumerable();

    return users;
  }

  public Task<UserEntity> FindUserById(ObjectId userId)
  {
    UserEntity user = _userRepository.Find([userId])
      ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"User not found with user identifier \"{userId}\"");

    return Task.FromResult(user);
  }

  public async Task<UserEntity> FindUserByUsernameOrEmail(string usernameOrEmail)
  {
    UserEntity user = await GetUsers()
      .FirstOrDefaultAsync(user => StringCommonHelper.IsStringEquivalent(user.Username, usernameOrEmail) || StringCommonHelper.IsStringEquivalent(user.Email, usernameOrEmail))
      ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"User not found with user username or email \"{usernameOrEmail}\"");

    return user;
  }
}
