using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MongoFramework;
using RealEstateProperties.Contracts.Mongo.Repository;

namespace RealEstateProperties.Infrastructure.Mongo.Repositories;

public abstract class Repository<TContext, TEntity>(IRepositoryContext<TContext> context) : IRepository<TContext, TEntity>
  where TContext : MongoDbContext
  where TEntity : class
{
  readonly IMongoDbSet<TEntity> _entitySet = context.Set<TEntity>();
  readonly IQueryable<TEntity> _query = context.Query<TEntity>();

  public void Create(TEntity entity) => _entitySet.Add(entity);

  public void CreateRange(IEnumerable<TEntity> entities) => _entitySet.AddRange(entities);

  public void Update(TEntity entity) => _entitySet.Update(entity);

  public void UpdateRange(IEnumerable<TEntity> entities) => _entitySet.UpdateRange(entities);

  public void Delete(TEntity entity) => _entitySet.Remove(entity);

  public void DeleteRange(IEnumerable<TEntity> entities) => _entitySet.RemoveRange(entities);

  public TEntity? Find(object id, params Expression<Func<TEntity, object>>[] navigations)
  {
    TEntity? found = _entitySet.Find(id);

    return found is not null ? WithNavigations(navigations).SingleOrDefault(entity => entity == found) : null;
  }

  public TEntity? Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigations) => WithNavigations(navigations).FirstOrDefault(predicate);

  public bool Exists(Expression<Func<TEntity, bool>> predicate) => _query.Any(predicate);

  public IEnumerable<TEntity> GetAll(
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
    params Expression<Func<TEntity, object>>[] navigations) => [.. orderBy is not null ? orderBy(WithNavigations(navigations)).AsQueryable() : WithNavigations(navigations)];

  public IEnumerable<TEntity> GetByFilter(
    Expression<Func<TEntity, bool>> filter,
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
    params Expression<Func<TEntity, object>>[] navigations) => [.. (orderBy is not null ? orderBy(WithNavigations(navigations)) : WithNavigations(navigations)).Where(filter)];

  private IQueryable<TEntity> WithNavigations(params Expression<Func<TEntity, object>>[] navigations)
  {
    if (navigations.Length == 0)
      return _query;

    var query = _query;
    foreach (var expression in navigations)
      query = query.Include(expression);

    return query;
  }
}
