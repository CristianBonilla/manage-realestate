using MongoDB.Bson;
using RealEstateProperties.Domain.Entities.Mongo;

namespace RealEstateProperties.Contracts.Mongo.Services;

public interface IPropertiesService
{
  Task<PropertyEntity> AddProperty(PropertyEntity property);
  Task<PropertyEntity> UpdateProperty(ObjectId propertyId, PropertyEntity property);
  Task<PropertyEntity> DeleteProperty(ObjectId propertyId);
  IAsyncEnumerable<(OwnerEntity Owner, PropertyEntity? Property, PropertyTraceEntity? PropertyTrace)> GetProperties();
  IAsyncEnumerable<(OwnerEntity Owner, PropertyEntity? Property, PropertyTraceEntity? PropertyTrace)> GetProperties(string text);
  Task<PropertyEntity> FindPropertyById(ObjectId propertyId);
  Task<PropertyImageEntity> AddPropertyImage(ObjectId propertyId, byte[] image, string imageName);
  Task<PropertyImageEntity> UpdatePropertyImage(ObjectId propertyId, ObjectId propertyImageId, byte[] image, string imageName);
  Task<PropertyImageEntity> DeletePropertyImage(ObjectId propertyId, ObjectId propertyImageId);
  (string PropertyName, IEnumerable<PropertyImageEntity> PropertyImages) GetPropertyImages(ObjectId propertyId);
  Task<PropertyTraceEntity> AddPropertyTrace(PropertyTraceEntity propertyTrace);
  IAsyncEnumerable<PropertyTraceEntity> GetPropertyTraces(ObjectId propertyId);
}
