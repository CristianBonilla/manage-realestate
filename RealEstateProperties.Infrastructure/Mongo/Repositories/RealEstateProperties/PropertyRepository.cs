using RealEstateProperties.Domain.Entities.Mongo;
using RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties;
using RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties.Interfaces;

namespace RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties;

public class PropertyRepository(IRealEstatePropertiesRepositoryContext context) : Repository<RealEstatePropertiesContext, PropertyEntity>(context), IPropertyRepository { }
