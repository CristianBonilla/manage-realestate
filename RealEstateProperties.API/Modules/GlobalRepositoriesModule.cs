using Autofac;
using RealEstateProperties.Contracts.Mongo.Repository;
using RealEstateProperties.Infrastructure.Mongo.Repositories;
using RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties;
using RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties.Interfaces;

namespace RealEstateProperties.API.Modules;

class GlobalRepositoriesModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterGeneric(typeof(RepositoryContext<>))
      .As(typeof(IRepositoryContext<>))
      .InstancePerLifetimeScope();
    builder.RegisterGeneric(typeof(Repository<,>))
      .As(typeof(IRepository<,>))
      .InstancePerLifetimeScope();
    builder.RegisterType<RealEstatePropertiesRepositoryContext>()
      .As<IRealEstatePropertiesRepositoryContext>()
      .InstancePerLifetimeScope();
  }
}
