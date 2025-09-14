using RealEstateProperties.Contracts.Mongo.Repository;
using RealEstateProperties.Domain.Entities.Mongo;
using RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties;

namespace RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties.Interfaces;

public interface IPropertyTraceRepository : IRepository<RealEstatePropertiesContext, PropertyTraceEntity> { }
