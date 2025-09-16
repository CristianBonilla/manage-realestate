using RealEstateProperties.Domain.Entities.Mongo;
using RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties;
using RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties.Interfaces;
using RealEstateProperties.Infrastructure.Repositories;

namespace RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties;

public class PropertyImageRepository(IRealEstatePropertiesRepositoryContext context) : Repository<RealEstatePropertiesContext, PropertyImageEntity>(context), IPropertyImageRepository { }
