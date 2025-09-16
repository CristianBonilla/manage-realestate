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
    OwnerEntity addedOwner = _ownerRepository.Create(owner);
    _ = await _context.SaveAsync();

    return addedOwner;
  }

  public async Task<OwnerEntity> DeleteOwner(ObjectId ownerId)
  {
    OwnerEntity owner = GetOwner(ownerId);
    OwnerEntity deletedOwner = _ownerRepository.Delete(owner);
    _ = await _context.SaveAsync();

    return deletedOwner;
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

  private OwnerEntity GetOwner(ObjectId ownerId)
  {
    OwnerEntity owner = _ownerRepository.Find([ownerId])
      ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Owner not found with owner identifier \"{ownerId}\"");

    return owner;
  }
}
