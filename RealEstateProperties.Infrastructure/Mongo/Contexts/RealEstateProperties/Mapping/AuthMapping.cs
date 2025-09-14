using MongoFramework.Infrastructure.Mapping;
using RealEstateProperties.Contracts.Mongo;
using RealEstateProperties.Domain.Entities.Mongo.Auth;

namespace RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties.Mapping;

class UserMapping : IEntityMapping<UserEntity>
{
  public void Configure(EntityDefinitionBuilder<UserEntity> builder)
  {
    builder
      .ToCollection("user")
      .HasKey(key => key.UserId, config => config.HasKeyGenerator(EntityKeyGenerators.ObjectIdKeyGenerator))
      .HasProperty(property => property.UserId, config => config.HasElementName("userId"))
      .HasProperty(property => property.DocumentNumber, config => config.HasElementName("documentNumber"))
      .HasProperty(property => property.Mobile, config => config.HasElementName("mobile"))
      .HasProperty(property => property.Username, config => config.HasElementName("username"))
      .HasProperty(property => property.Password, config => config.HasElementName("password"))
      .HasProperty(property => property.Email, config => config.HasElementName("email"))
      .HasProperty(property => property.Firstname, config => config.HasElementName("firstname"))
      .HasProperty(property => property.Lastname, config => config.HasElementName("lastname"))
      .HasProperty(property => property.IsActive, config => config.HasElementName("isActive"))
      .HasProperty(property => property.Salt, config => config.HasElementName("salt"))
      .HasProperty(property => property.Created, config => config.HasElementName("created"))
      .HasIndex(index => new
      {
        index.DocumentNumber,
        index.Username,
        index.Email,
        index.Mobile
      }, config => config.HasName("UserUniqueIndex").IsUnique());
  }
}
