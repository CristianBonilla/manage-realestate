using MongoFramework;

namespace RealEstateProperties.Contracts.Mongo.Repository;

public interface IRepositoryContext<in TContext> : IDisposable where TContext : MongoDbContext
{
  void Attach<TEntity>(TEntity entity) where TEntity : class;
  void AttachRange<TEntity>(IEnumerable<TEntity> entity) where TEntity : class;
  IMongoDbSet<TEntity> Set<TEntity>() where TEntity : class;
  IQueryable<TEntity> Query<TEntity>() where TEntity : class;
  void Save();
  Task SaveAsync();
}
