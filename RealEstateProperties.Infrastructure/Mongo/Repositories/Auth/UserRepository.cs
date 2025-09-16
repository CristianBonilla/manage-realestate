using RealEstateProperties.Domain.Entities.Mongo.Auth;
using RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties;
using RealEstateProperties.Infrastructure.Mongo.Repositories.Auth.Interfaces;
using RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties.Interfaces;
using RealEstateProperties.Infrastructure.Repositories;

namespace RealEstateProperties.Infrastructure.Mongo.Repositories.Auth;

public class UserRepository(IRealEstatePropertiesRepositoryContext context) : Repository<RealEstatePropertiesContext, UserEntity>(context), IUserRepository { }
