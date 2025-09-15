using Autofac;
using RealEstateProperties.Contracts.Mongo.SeedData;
using RealEstateProperties.Domain.Mongo.SeedWork;

namespace RealEstateProperties.API.Modules;

class DbModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<SeedData>()
      .As<ISeedData>()
      .InstancePerLifetimeScope();
  }
}
