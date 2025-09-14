using MongoFramework;
using RealEstateProperties.Contracts.Mongo;

namespace RealEstateProperties.Infrastructure.Mongo.Extensions;

static class EntityMappingExtensions
{
  public static MappingBuilder ApplyEntityMapping<TEntity, TMapping>(this MappingBuilder builder)
    where TEntity : class
    where TMapping : IEntityMapping<TEntity>
  {
    TMapping entityMapping = Activator.CreateInstance<TMapping>() 
      ?? throw new NullReferenceException($"The entity mapping {typeof(TMapping)} instance was not created correctly");
    entityMapping.Configure(builder.Entity<TEntity>());

    return builder;
  }
}
