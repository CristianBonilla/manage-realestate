using MongoFramework.Infrastructure.Mapping;

namespace RealEstateProperties.Contracts.Mongo;

public interface IEntityMapping<TEntity> where TEntity : class
{
  void Configure(EntityDefinitionBuilder<TEntity> builder);
}
