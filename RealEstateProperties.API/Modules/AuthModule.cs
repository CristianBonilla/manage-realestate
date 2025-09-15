using Autofac;
using RealEstateProperties.API.Identity;
using RealEstateProperties.Contracts.Mongo.Identity;
using RealEstateProperties.Contracts.Mongo.Services;
using RealEstateProperties.Domain.Mongo.Services;
using RealEstateProperties.Infrastructure.Mongo.Repositories.Auth;
using RealEstateProperties.Infrastructure.Mongo.Repositories.Auth.Interfaces;

namespace RealEstateProperties.API.Modules;

class AuthModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<UserRepository>()
      .As<IUserRepository>()
      .InstancePerLifetimeScope();
    builder.RegisterType<AuthService>()
      .As<IAuthService>()
      .InstancePerLifetimeScope();
    builder.RegisterType<AuthIdentity>()
      .As<IAuthIdentity>()
      .InstancePerLifetimeScope();
  }
}
