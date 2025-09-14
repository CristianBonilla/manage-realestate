using RealEstateProperties.Contracts.DTO.User;
using RealEstateProperties.Contracts.Mongo.DTO.Auth;

namespace RealEstateProperties.Contracts.Mongo.Identity;

public interface IAuthIdentity
{
  Task<AuthResult> Register(UserRegisterRequest userRegisterRequest);
  Task<AuthResult> Login(UserLoginRequest userLoginRequest);
  Task<bool> UserExists(UserRegisterRequest user);
}
