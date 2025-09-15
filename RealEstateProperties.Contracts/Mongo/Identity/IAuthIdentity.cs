using RealEstateProperties.Contracts.Mongo.DTO.Auth;
using RealEstateProperties.Contracts.Mongo.DTO.User;

namespace RealEstateProperties.Contracts.Mongo.Identity;

public interface IAuthIdentity
{
  Task<AuthResult> Register(UserRegisterRequest userRegisterRequest);
  Task<AuthResult> Login(UserLoginRequest userLoginRequest);
  Task<bool> UserExists(UserRegisterRequest user);
}
