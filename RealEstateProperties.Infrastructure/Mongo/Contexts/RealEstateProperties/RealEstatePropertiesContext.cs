using MongoFramework;
using RealEstateProperties.Domain.Entities.Mongo;
using RealEstateProperties.Domain.Entities.Mongo.Auth;
using RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties.Mapping;
using RealEstateProperties.Infrastructure.Mongo.Extensions;

namespace RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties;

public class RealEstatePropertiesContext(IMongoDbConnection connection) : MongoDbContext(connection)
{
  protected override void OnConfigureMapping(MappingBuilder mappingBuilder)
  {
    mappingBuilder.ApplyEntityMapping<UserEntity, UserMapping>()
      .ApplyEntityMapping<OwnerEntity, OwnerMapping>()
      .ApplyEntityMapping<PropertyEntity, PropertyMapping>()
      .ApplyEntityMapping<PropertyImageEntity, PropertyImageMapping>()
      .ApplyEntityMapping<PropertyTraceEntity, PropertyTraceMapping>();
  }
}
