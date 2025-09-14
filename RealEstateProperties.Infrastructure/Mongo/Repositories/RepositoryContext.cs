using MongoFramework;
using RealEstateProperties.Contracts.Mongo.Repository;

namespace RealEstateProperties.Infrastructure.Mongo.Repositories;

public abstract class RepositoryContext<TContext>(TContext context) : IRepositoryContext<TContext> where TContext : MongoDbContext
{
  readonly TContext _context = context;
  bool _disposed = false;

  public void Attach<TEntity>(TEntity entity) where TEntity : class
  {
    _context.Attach(entity);
  }

  public void AttachRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
  {
    _context.AttachRange(entities);
  }

  public IMongoDbSet<TEntity> Set<TEntity>() where TEntity : class
  {
    return _context.Set<TEntity>();
  }

  public IQueryable<TEntity> Query<TEntity>() where TEntity : class
  {
    return _context.Query<TEntity>();
  }

  public void Save() => _context.SaveChanges();

  public Task SaveAsync() => _context.SaveChangesAsync();

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (_disposed)
      return;
    if (disposing)
      _context.Dispose();
    _disposed = true;
  }
}
