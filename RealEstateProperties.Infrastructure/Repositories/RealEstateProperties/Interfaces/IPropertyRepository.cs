using RealEstateProperties.Contracts.Repository;
using RealEstateProperties.Domain.Entities;
using RealEstateProperties.Infrastructure.Contexts.RealEstateProperties;

namespace RealEstateProperties.Infrastructure.Repositories.RealEstateProperties.Interfaces;

public interface IPropertyRepository : IRepository<RealEstatePropertiesContext, PropertyEntity> { }
