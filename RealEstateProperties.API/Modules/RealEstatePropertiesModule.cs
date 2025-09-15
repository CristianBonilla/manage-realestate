using Autofac;
using RealEstateProperties.Contracts.Mongo.Services;
using RealEstateProperties.Domain.Mongo.Services;
using RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties;
using RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties.Interfaces;

namespace RealEstateProperties.API.Modules;

class RealEstatePropertiesModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<OwnerRepository>()
      .As<IOwnerRepository>()
      .InstancePerLifetimeScope();
    builder.RegisterType<PropertyRepository>()
      .As<IPropertyRepository>()
      .InstancePerLifetimeScope();
    builder.RegisterType<PropertyImageRepository>()
      .As<IPropertyImageRepository>()
      .InstancePerLifetimeScope();
    builder.RegisterType<PropertyTraceRepository>()
      .As<IPropertyTraceRepository>()
      .InstancePerLifetimeScope();

    builder.RegisterType<OwnerService>()
      .As<IOwnerService>()
      .InstancePerLifetimeScope();
    builder.RegisterType<PropertiesService>()
      .As<IPropertiesService>()
      .InstancePerLifetimeScope();
  }
}
