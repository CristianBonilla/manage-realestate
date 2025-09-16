using RealEstateProperties.Contracts.Repository;
using RealEstateProperties.Domain.Entities.Mongo;
using RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties;

namespace RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties.Interfaces;

public interface IOwnerRepository : IRepository<RealEstatePropertiesContext, OwnerEntity> { }
