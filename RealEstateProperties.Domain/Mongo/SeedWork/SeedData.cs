using Microsoft.EntityFrameworkCore;
using RealEstateProperties.Contracts.Mongo.SeedData;
using RealEstateProperties.Domain.Mongo.SeedWork.Collections;
using RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties.Interfaces;

namespace RealEstateProperties.Domain.Mongo.SeedWork;

public class SeedData(IRealEstatePropertiesRepositoryContext context) : ISeedData
{
  public async Task LoadAsync()
  {
    LoadData(AuthCollection.Users.GetAll());
    LoadData(RealEstatePropertiesCollection.Owners.GetAll());
    LoadData(RealEstatePropertiesCollection.Properties.GetAll());
    LoadData(RealEstatePropertiesCollection.PropertyImages.GetAll());
    LoadData(RealEstatePropertiesCollection.PropertyTraces.GetAll());

    await context.SaveAsync();
  }

  private void LoadData<TEntity>(IEnumerable<TEntity> source) where TEntity : class
  {
    var entities = context.Set<TEntity>();
    if (entities.Any())
      return;
    entities.AddRange(source);
  }
}
