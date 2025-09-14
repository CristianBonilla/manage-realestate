using System.Linq.Expressions;
using MongoFramework;

namespace RealEstateProperties.Contracts.Mongo.Repository;

public interface IRepository<in TContext, TEntity>
  where TContext : MongoDbContext
  where TEntity : class
{
  void Create(TEntity entity);
  void CreateRange(IEnumerable<TEntity> entities);
  void Update(TEntity entity);
  void UpdateRange(IEnumerable<TEntity> entities);
  void Delete(TEntity entity);
  void DeleteRange(IEnumerable<TEntity> entities);
  TEntity? Find(object id, params Expression<Func<TEntity, object>>[] navigations);
  TEntity? Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigations);
  bool Exists(Expression<Func<TEntity, bool>> predicate);
  IEnumerable<TEntity> GetAll(
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
    params Expression<Func<TEntity, object>>[] navigations);
  IEnumerable<TEntity> GetByFilter(
    Expression<Func<TEntity, bool>> filter,
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
    params Expression<Func<TEntity, object>>[] navigations);
}
