using RealEstateProperties.Contracts.Mongo.DTO.User;

namespace RealEstateProperties.Contracts.Mongo.DTO.Auth;

public record AuthResult(string Token, UserResponse User);
