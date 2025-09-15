using System.Net;
using MongoDB.Bson;
using RealEstateProperties.Contracts.Exceptions;
using RealEstateProperties.Contracts.Mongo.Services;
using RealEstateProperties.Domain.Entities.Mongo;
using RealEstateProperties.Domain.Helpers;
using RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties.Interfaces;

namespace RealEstateProperties.Domain.Mongo.Services;

public class PropertiesService(
  IRealEstatePropertiesRepositoryContext context,
  IOwnerRepository ownerRepository,
  IPropertyRepository propertyRepository,
  IPropertyImageRepository propertyImageRepository,
  IPropertyTraceRepository propertyTraceRepository) : IPropertiesService
{
  readonly IRealEstatePropertiesRepositoryContext _context = context;
  readonly IOwnerRepository _ownerRepository = ownerRepository;
  readonly IPropertyRepository _propertyRepository = propertyRepository;
  readonly IPropertyImageRepository _propertyImageRepository = propertyImageRepository;
  readonly IPropertyTraceRepository _propertyTraceRepository = propertyTraceRepository;

  public async Task<PropertyEntity> AddProperty(PropertyEntity property)
  {
    CheckOwnerExists(property.OwnerId);
    Random random = new();
    property.CodeInternal = random.Next();
    _propertyRepository.Create(property);
    await _context.SaveAsync();

    return property;
  }

  public async Task<PropertyEntity> UpdateProperty(ObjectId propertyId, PropertyEntity property)
  {
    CheckPropertyExists(propertyId);
    CheckOwnerExists(property.OwnerId);
    _propertyRepository.Update(property);
    await _context.SaveAsync();

    return property;
  }

  public async Task<PropertyEntity> DeleteProperty(ObjectId propertyId)
  {
    PropertyEntity property = GetProperty(propertyId);
    _propertyRepository.Delete(property);
    await _context.SaveAsync();

    return property;
  }

  public IAsyncEnumerable<(OwnerEntity Owner, PropertyEntity? Property, PropertyTraceEntity? PropertyTrace)> GetProperties()
  {
    var owners = _ownerRepository.GetAll()
      .GroupJoin(
        _propertyRepository.GetAll(),
        owner => owner.OwnerId,
        property => property.OwnerId,
        (owner, properties) => (owner, properties))
      .SelectMany(
        owner => owner.properties.DefaultIfEmpty(),
        (owner, property) => (owner.owner, property))
      .GroupJoin(
        _propertyTraceRepository.GetAll(),
        owner => owner.property?.PropertyId,
        propertyTrace => propertyTrace.PropertyId,
        (owner, propertyTraces) => (owner.owner, owner.property, propertyTraces))
      .SelectMany(
        owner => owner.propertyTraces.DefaultIfEmpty(),
        (owner, propertyTrace) => (owner.owner, owner.property, propertyTrace))
      .ToAsyncEnumerable();

    return owners;
  }

  public async IAsyncEnumerable<(OwnerEntity Owner, PropertyEntity? Property, PropertyTraceEntity? PropertyTrace)> GetProperties(string text)
  {
    var properties = GetProperties();
    await foreach (var (owner, property, propertyTrace) in properties)
    {
      bool ownerMatch = MatchesHelper.MatchesByText(
        owner,
        text,
        owner => owner.Name,
        owner => owner.Address);
      bool propertyMatch = property is not null && MatchesHelper.MatchesByText(
        property,
        text,
        property => property.Name,
        property => property.CodeInternal,
        property => property.Price,
        property => property.Year);
      bool propertyTraceMatch = propertyTrace is not null && MatchesHelper.MatchesByText(
        propertyTrace,
        text,
        propertyTrace => propertyTrace.Name,
        propertyTrace => propertyTrace.Value,
        propertyTrace => propertyTrace.Tax);
      if (ownerMatch || propertyMatch || propertyTraceMatch)
        yield return (owner, property, propertyTrace);
    }
  }

  public Task<PropertyEntity> FindPropertyById(ObjectId propertyId) => Task.FromResult(GetProperty(propertyId));

  public async Task<PropertyImageEntity> AddPropertyImage(ObjectId propertyId, byte[] image, string imageName)
  {
    CheckPropertyExists(propertyId);
    PropertyImageEntity propertyImage = new()
    {
      PropertyId = propertyId,
      Enabled = true,
      Image = image,
      ImageName = imageName
    };
    _propertyImageRepository.Create(propertyImage);
    await _context.SaveAsync();

    return propertyImage;
  }

  public async Task<PropertyImageEntity> UpdatePropertyImage(ObjectId propertyId, ObjectId propertyImageId, byte[] image, string imageName)
  {
    PropertyImageEntity propertyImage = GetPropertyImage(propertyId, propertyImageId);
    propertyImage.Enabled = true;
    propertyImage.Image = image;
    propertyImage.ImageName = imageName;
    _propertyImageRepository.Update(propertyImage);
    await _context.SaveAsync();

    return propertyImage;
  }

  public async Task<PropertyImageEntity> DeletePropertyImage(ObjectId propertyId, ObjectId propertyImageId)
  {
    PropertyImageEntity propertyImage = GetPropertyImage(propertyId, propertyImageId);
    _propertyImageRepository.Delete(propertyImage);
    await _context.SaveAsync();

    return propertyImage;
  }

  public (string PropertyName, IEnumerable<PropertyImageEntity> PropertyImages) GetPropertyImages(ObjectId propertyId)
  {
    PropertyEntity property = GetProperty(propertyId);
    var propertyImages = _propertyImageRepository.GetByFilter(propertyImage => propertyImage.PropertyId == propertyId);

    return (property.Name, propertyImages);
  }

  public async Task<PropertyTraceEntity> AddPropertyTrace(PropertyTraceEntity propertyTrace)
  {
    CheckPropertyExists(propertyTrace.PropertyId);
    _propertyTraceRepository.Create(propertyTrace);
    await _context.SaveAsync();

    return propertyTrace;
  }

  public IAsyncEnumerable<PropertyTraceEntity> GetPropertyTraces(ObjectId propertyId)
  {
    CheckPropertyExists(propertyId);
    var propertyTraces = _propertyTraceRepository.GetByFilter(propertyTrace => propertyTrace.PropertyId == propertyId)
      .ToAsyncEnumerable();

    return propertyTraces;
  }

  private void CheckOwnerExists(ObjectId ownerId)
  {
    bool existingOwner = _ownerRepository.Exists(owner => owner.OwnerId == ownerId);
    if (!existingOwner)
      throw new ServiceErrorException(HttpStatusCode.NotFound, $"Owner not found with owner identifier \"{ownerId}\"");
  }

  private void CheckPropertyExists(ObjectId propertyId)
  {
    bool existingProperty = _propertyRepository.Exists(property => property.PropertyId == propertyId);
    if (!existingProperty)
      throw new ServiceErrorException(HttpStatusCode.NotFound, $"Property not found with property identifier \"{propertyId}\"");
  }

  private PropertyEntity GetProperty(ObjectId propertyId)
  {
    PropertyEntity property = _propertyRepository.Find(property => property.PropertyId == propertyId)
      ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Property not found with property identifier \"{propertyId}\"");

    return property;
  }

  private PropertyImageEntity GetPropertyImage(ObjectId propertyId, ObjectId propertyImageId)
  {
    PropertyImageEntity propertyImage = _propertyImageRepository.Find(propertyImage => propertyImage.PropertyId == propertyId && propertyImage.PropertyImageId == propertyImageId)
      ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Property image not found with property identifier \"{propertyId}\" or property image identifier \"{propertyImageId}\"");

    return propertyImage;
  }
}
