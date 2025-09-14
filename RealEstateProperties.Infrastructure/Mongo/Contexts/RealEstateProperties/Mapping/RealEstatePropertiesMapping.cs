using MongoFramework.Infrastructure.Mapping;
using RealEstateProperties.Contracts.Mongo;
using RealEstateProperties.Domain.Entities.Mongo;

namespace RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties.Mapping;

class OwnerMapping : IEntityMapping<OwnerEntity>
{
  public void Configure(EntityDefinitionBuilder<OwnerEntity> builder)
  {
    builder
      .ToCollection("owner")
      .HasKey(key => key.OwnerId, config => config.HasKeyGenerator(EntityKeyGenerators.ObjectIdKeyGenerator))
      .HasProperty(property => property.OwnerId, config => config.HasElementName("ownerId"))
      .HasProperty(property => property.Name, config => config.HasElementName("name"))
      .HasProperty(property => property.Address, config => config.HasElementName("address"))
      .HasProperty(property => property.Photo, config => config.HasElementName("photo"))
      .HasProperty(property => property.PhotoName, config => config.HasElementName("photoName"))
      .HasProperty(property => property.Birthday, config => config.HasElementName("birthday"))
      .HasProperty(property => property.Created, config => config.HasElementName("created"))
      .HasIndex(index => index.Name, config => config.HasName("OwnerNameUniqueIndex").IsUnique());
  }
}

class PropertyMapping : IEntityMapping<PropertyEntity>
{
  public void Configure(EntityDefinitionBuilder<PropertyEntity> builder)
  {
    builder
      .ToCollection("property")
      .HasKey(key => key.PropertyId, config => config.HasKeyGenerator(EntityKeyGenerators.ObjectIdKeyGenerator))
      .HasProperty(property => property.PropertyId, config => config.HasElementName("propertyId"))
      .HasProperty(property => property.Name, config => config.HasElementName("name"))
      .HasProperty(property => property.Address, config => config.HasElementName("address"))
      .HasProperty(property => property.Price, config => config.HasElementName("price"))
      .HasProperty(property => property.CodeInternal, config => config.HasElementName("codeInternal"))
      .HasProperty(property => property.Year, config => config.HasElementName("year"))
      .HasProperty(property => property.Created, config => config.HasElementName("created"))
      .HasIndex(index => new
      {
        index.Name,
        index.CodeInternal
      }, config => config.HasName("PropertyUniqueIndex").IsUnique());
  }
}

class PropertyImageMapping : IEntityMapping<PropertyImageEntity>
{
  public void Configure(EntityDefinitionBuilder<PropertyImageEntity> builder)
  {
    builder
      .ToCollection("propertyImage")
      .HasKey(key => key.PropertyImageId, config => config.HasKeyGenerator(EntityKeyGenerators.ObjectIdKeyGenerator))
      .HasProperty(property => property.PropertyImageId, config => config.HasElementName("propertyImageId"))
      .HasProperty(property => property.PropertyId, config => config.HasElementName("propertyId"))
      .HasProperty(property => property.Image, config => config.HasElementName("image"))
      .HasProperty(property => property.ImageName, config => config.HasElementName("imageName"))
      .HasProperty(property => property.Enabled, config => config.HasElementName("enabled"))
      .HasProperty(property => property.Created, config => config.HasElementName("created"))
      .HasIndex(index => index.ImageName, config => config.HasName("PropertyImageNameUniqueIndex").IsUnique());
  }
}

class PropertyTraceMapping : IEntityMapping<PropertyTraceEntity>
{
  public void Configure(EntityDefinitionBuilder<PropertyTraceEntity> builder)
  {
    builder
      .ToCollection("propertyTrace")
      .HasKey(key => key.PropertyTraceId, config => config.HasKeyGenerator(EntityKeyGenerators.ObjectIdKeyGenerator))
      .HasProperty(property => property.PropertyTraceId, config => config.HasElementName("propertyTraceId"))
      .HasProperty(property => property.PropertyId, config => config.HasElementName("propertyId"))
      .HasProperty(property => property.Name, config => config.HasElementName("name"))
      .HasProperty(property => property.Value, config => config.HasElementName("value"))
      .HasProperty(property => property.Tax, config => config.HasElementName("tax"))
      .HasProperty(property => property.DateSale, config => config.HasElementName("dateSale"))
      .HasProperty(property => property.Created, config => config.HasElementName("created"))
      .HasIndex(index => index.Name, config => config.HasName("PropertyTraceNameUniqueIndex").IsUnique());
  }
}
