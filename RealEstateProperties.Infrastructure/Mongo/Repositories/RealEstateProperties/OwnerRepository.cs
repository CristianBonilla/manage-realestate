using RealEstateProperties.Domain.Entities.Mongo;
using RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties;
using RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties.Interfaces;

namespace RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties;

public class OwnerRepository(IRealEstatePropertiesRepositoryContext context) : Repository<RealEstatePropertiesContext, OwnerEntity>(context), IOwnerRepository { }
