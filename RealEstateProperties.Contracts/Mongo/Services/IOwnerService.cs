using MongoDB.Bson;
using RealEstateProperties.Domain.Entities.Mongo;

namespace RealEstateProperties.Contracts.Mongo.Services;

public interface IOwnerService
{
  Task<OwnerEntity> AddOwner(OwnerEntity owner);
  Task<OwnerEntity> DeleteOwner(ObjectId ownerId);
  IAsyncEnumerable<OwnerEntity> GetOwners();
  Task<OwnerEntity> FindOwnerById(ObjectId ownerId);
  Task<OwnerEntity> AddOrUpdateOwnerPhoto(ObjectId ownerId, byte[] photo, string photoName);
}
