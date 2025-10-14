using System.Net;
using RealEstateProperties.Contracts.Exceptions;
using RealEstateProperties.Contracts.Services;
using RealEstateProperties.Domain.Entities;
using RealEstateProperties.Domain.Helpers;
using RealEstateProperties.Infrastructure.Repositories.RealEstateProperties.Interfaces;

namespace RealEstateProperties.Domain.Services;

public class OwnerService(IRealEstatePropertiesRepositoryContext context, IOwnerRepository ownerRepository) : IOwnerService
{
  readonly IRealEstatePropertiesRepositoryContext _context = context;
  readonly IOwnerRepository _ownerRepository = ownerRepository;

  public async Task<OwnerEntity> AddOwner(OwnerEntity owner)
  {
    await CheckOwnerByName(owner.Name);
    OwnerEntity addedOwner = _ownerRepository.Create(owner);
    _ = await _context.SaveAsync();

    return addedOwner;
  }

  public async Task<OwnerEntity> DeleteOwner(Guid ownerId)
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

  public Task<OwnerEntity> FindOwnerById(Guid ownerId) => Task.FromResult(GetOwner(ownerId));

  public async Task<OwnerEntity> AddOrUpdateOwnerPhoto(Guid ownerId, byte[] photo, string photoName)
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

  private OwnerEntity GetOwner(Guid ownerId)
  {
    OwnerEntity owner = _ownerRepository.Find([ownerId])
      ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Owner not found with owner identifier \"{ownerId}\"");

    return owner;
  }
}
