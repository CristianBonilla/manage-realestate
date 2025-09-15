using AutoMapper;
using RealEstateProperties.Contracts.Mongo.DTO.User;
using RealEstateProperties.Domain.Entities.Mongo.Auth;

namespace RealEstateProperties.API.Mappers;

class AuthProfile : Profile
{
  public AuthProfile()
  {
    CreateMap<UserRegisterRequest, UserEntity>()
      .ForMember(member => member.UserId, options => options.Ignore())
      .ForMember(member => member.IsActive, options => options.Ignore())
      .ForMember(member => member.Salt, options => options.Ignore())
      .ForMember(member => member.Created, options => options.Ignore());
    CreateMap<UserEntity, UserResponse>()
      .ReverseMap()
      .ForMember(member => member.Password, options => options.Ignore())
      .ForMember(member => member.Salt, options => options.Ignore());
  }
}
