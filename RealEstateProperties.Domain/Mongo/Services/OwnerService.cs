using System.Net;
using MongoDB.Bson;
using RealEstateProperties.Contracts.Exceptions;
using RealEstateProperties.Contracts.Mongo.Services;
using RealEstateProperties.Domain.Entities.Mongo;
using RealEstateProperties.Domain.Helpers;
using RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties.Interfaces;

namespace RealEstateProperties.Domain.Mongo.Services;

public class OwnerService(
  IRealEstatePropertiesRepositoryContext context,
  IOwnerRepository ownerRepository,
  IPropertyRepository propertyRepository,
  IPropertyImageRepository propertyImageRepository,
  IPropertyTraceRepository propertyTraceRepository) : IOwnerService
{
  readonly IRealEstatePropertiesRepositoryContext _context = context;
  readonly IOwnerRepository _ownerRepository = ownerRepository;
  readonly IPropertyRepository _propertyRepository = propertyRepository;
  readonly IPropertyImageRepository _propertyImageRepository = propertyImageRepository;
  readonly IPropertyTraceRepository _propertyTraceRepository = propertyTraceRepository;

  public async Task<OwnerEntity> AddOwner(OwnerEntity owner)
  {
    await CheckOwnerByName(owner.Name);
    OwnerEntity addedOwner = _ownerRepository.Create(owner);
    _ = await _context.SaveAsync();

    return addedOwner;
  }

  public async Task<OwnerEntity> DeleteOwner(ObjectId ownerId)
  {
    OwnerEntity owner = GetOwner(ownerId);
    var propertiesByOwner = _propertyRepository.GetByFilter(property => property.OwnerId == ownerId);
    foreach (PropertyEntity property in propertiesByOwner)
    {
      DeletePropertyDependencies(property);
    }
    _ = _propertyRepository.DeleteRange(propertiesByOwner);
    OwnerEntity deletedOwner = _ownerRepository.Delete(owner);
    _ = await _context.SaveAsync();

    return deletedOwner;

    void DeletePropertyDependencies(PropertyEntity property)
    {
      var propertyImages = _propertyImageRepository.GetByFilter(propertyImage => propertyImage.PropertyId == property.PropertyId);
      var propertyTraces = _propertyTraceRepository.GetByFilter(propertyTrace => propertyTrace.PropertyId == property.PropertyId);
      _ = _propertyImageRepository.DeleteRange(propertyImages);
      _ = _propertyTraceRepository.DeleteRange(propertyTraces);
    }
  }

  public IAsyncEnumerable<OwnerEntity> GetOwners()
  {
    var owners = _ownerRepository.GetAll(owner => owner.OrderBy(order => order.Name))
      .ToAsyncEnumerable();

    return owners;
  }

  public Task<OwnerEntity> FindOwnerById(ObjectId ownerId) => Task.FromResult(GetOwner(ownerId));

  public async Task<OwnerEntity> AddOrUpdateOwnerPhoto(ObjectId ownerId, byte[] photo, string photoName)
  {
    OwnerEntity owner = GetOwner(ownerId);
    owner.Photo = photo;
    owner.PhotoName = photoName;
    OwnerEntity updatedOwner = _ownerRepository.Update(owner);
    _ = await _context.SaveAsync();

    return updatedOwner;
  }

  private async Task CheckOwnerByName(string ownerName)
  {
    bool existingOwner = await GetOwners()
      .AnyAsync(owner => StringCommonHelper.IsStringEquivalent(owner.Name, ownerName));
    if (existingOwner)
      throw new ServiceErrorException(HttpStatusCode.BadRequest, $"Owner with the name \"{ownerName}\" already exists");
  }

  private OwnerEntity GetOwner(ObjectId ownerId)
  {
    OwnerEntity owner = _ownerRepository.Find([ownerId])
      ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Owner not found with owner identifier \"{ownerId}\"");

    return owner;
  }
}
