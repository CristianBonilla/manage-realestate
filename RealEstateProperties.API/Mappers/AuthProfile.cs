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
      .ForMember(member => member.CreatedAt, options => options.Ignore())
      .ForMember(member => member.UpdatedAt, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore());
    CreateMap<UserEntity, UserResponse>()
      .ForMember(member => member.UserId, options => options.MapFrom(user => user.UserId.ToString()))
      .ReverseMap()
      .ForMember(member => member.Password, options => options.Ignore())
      .ForMember(member => member.Salt, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore());
  }
}
