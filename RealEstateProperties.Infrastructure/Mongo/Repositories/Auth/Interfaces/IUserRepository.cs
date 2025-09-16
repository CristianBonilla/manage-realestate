using RealEstateProperties.Contracts.Repository;
using RealEstateProperties.Domain.Entities.Mongo.Auth;
using RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties;

namespace RealEstateProperties.Infrastructure.Mongo.Repositories.Auth.Interfaces;

public interface IUserRepository : IRepository<RealEstatePropertiesContext, UserEntity> { }
