using System.Net;
using MongoDB.Bson;
using RealEstateProperties.Contracts.Exceptions;
using RealEstateProperties.Contracts.Mongo.Services;
using RealEstateProperties.Domain.Entities.Mongo;
using RealEstateProperties.Infrastructure.Mongo.Repositories.RealEstateProperties.Interfaces;

namespace RealEstateProperties.Domain.Mongo.Services;

public class OwnerService(IRealEstatePropertiesRepositoryContext context, IOwnerRepository ownerRepository) : IOwnerService
{
  readonly IRealEstatePropertiesRepositoryContext _context = context;
  readonly IOwnerRepository _ownerRepository = ownerRepository;

  public async Task<OwnerEntity> AddOwner(OwnerEntity owner)
  {
    _ownerRepository.Create(owner);
    await _context.SaveAsync();

    return owner;
  }

  public async Task<OwnerEntity> DeleteOwner(ObjectId ownerId)
  {
    OwnerEntity owner = GetOwner(ownerId);
    _ownerRepository.Delete(owner);
    await _context.SaveAsync();

    return owner;
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
    _ownerRepository.Update(owner);
    await _context.SaveAsync();

    return owner;
  }

  private OwnerEntity GetOwner(ObjectId ownerId)
  {
    OwnerEntity owner = _ownerRepository.Find(owner => owner.OwnerId == ownerId)
      ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Owner not found with owner identifier \"{ownerId}\"");

    return owner;
  }
}
