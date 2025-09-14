using Microsoft.EntityFrameworkCore;
using RealEstateProperties.Contracts.Mongo.SeedData;
using RealEstateProperties.Domain.Mongo.SeedWork.Collections;
using RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties.Interfaces;

namespace RealEstateProperties.Domain.Mongo.SeedWork;

public class SeedData(IRealEstatePropertiesRepositoryContext context) : ISeedData
{
  public async Task LoadAsync()
  {
    await LoadData(AuthCollection.Users.GetAll());
    await LoadData(RealEstatePropertiesCollection.Owners.GetAll());
    await LoadData(RealEstatePropertiesCollection.Properties.GetAll());
    await LoadData(RealEstatePropertiesCollection.PropertyImages.GetAll());
    await LoadData(RealEstatePropertiesCollection.PropertyTraces.GetAll());

    await context.SaveAsync();
  }

  private async Task LoadData<TEntity>(IEnumerable<TEntity> source) where TEntity : class
  {
    var entities = context.Set<TEntity>();
    if (await entities.AnyAsync())
      return;
    entities.AddRange(source);
  }
}
