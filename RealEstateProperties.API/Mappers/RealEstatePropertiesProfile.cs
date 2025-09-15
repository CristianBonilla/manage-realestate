using AutoMapper;
using RealEstateProperties.API.Mappers.Converters;
using RealEstateProperties.Contracts.Mongo.DTO.Owner;
using RealEstateProperties.Contracts.Mongo.DTO.Properties;
using RealEstateProperties.Domain.Entities.Mongo;

namespace RealEstateProperties.API.Mappers;

class RealEstatePropertiesProfile : Profile
{
  public RealEstatePropertiesProfile()
  {
    CreateMap<OwnerRequest, OwnerEntity>()
      .ForMember(member => member.OwnerId, options => options.Ignore())
      .ForMember(member => member.Photo, options => options.Ignore())
      .ForMember(member => member.PhotoName, options => options.Ignore())
      .ForMember(member => member.Created, options => options.Ignore());
    CreateMap<OwnerEntity, OwnerResponse>()
      .ForMember(member => member.OwnerId, options => options.MapFrom(owner => owner.OwnerId.ToString()));
    CreateMap<PropertyRequest, PropertyEntity>()
      .ForMember(member => member.PropertyId, options => options.Ignore())
      .ForMember(member => member.Created, options => options.Ignore());
    CreateMap<PropertyEntity, PropertyResponse>()
      .ForMember(member => member.PropertyId, options => options.MapFrom(property => property.PropertyId.ToString()))
      .ForMember(member => member.PropertyTraces, options => options.Ignore())
      .ReverseMap()
      .ForMember(member => member.CodeInternal, options => options.Ignore());
    CreateMap<PropertyImageEntity, PropertyImageResponse>()
      .ForMember(member => member.PropertyImageId, options => options.MapFrom(image => image.PropertyImageId.ToString()))
      .ReverseMap()
      .ForMember(member => member.Image, options => options.Ignore());
    CreateMap<PropertyTraceRequest, PropertyTraceEntity>()
      .ForMember(member => member.PropertyTraceId, options => options.Ignore())
      .ForMember(member => member.Created, options => options.Ignore());
    CreateMap<PropertyTraceEntity, PropertyTraceResponse>()
      .ForMember(member => member.PropertyTraceId, options => options.MapFrom(propertyTrace => propertyTrace.PropertyTraceId.ToString()));
    CreateMap<IAsyncEnumerable<(
      OwnerEntity Owner,
      PropertyEntity? Property,
      PropertyTraceEntity? PropertyTrace)>,
      IAsyncEnumerable<PropertiesResult>>()
      .ConvertUsing<PropertiesFilterConverter>();
  }
}
