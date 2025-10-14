using RealEstateProperties.Contracts.SeedData;
using RealEstateProperties.Domain.Entities.Mongo;
using RealEstateProperties.Domain.SeedWork;

namespace RealEstateProperties.Domain.Mongo.SeedWork.Collections.RealEstateProperties;

class PropertyImageCollection : SeedDataCollection<PropertyImageEntity>
{
  static readonly PropertyCollection _properties = RealEstatePropertiesCollection.Properties;

  protected override PropertyImageEntity[] Collection => [
    new()
    {
      PropertyImageId = new("68ed98ea5e9a77cf7005835a"),
      PropertyId = _properties[0].PropertyId,
      Image = SeedImagesData.PropertyImages[0],
      ImageName = "2a657822-056c-4dd9-8491-489998230a7c.webp",
      Enabled = true,
      CreatedAt = _properties[0].CreatedAt
    },
    new()
    {
      PropertyImageId = new("68ed98ea5e9a77cf7005835b"),
      PropertyId = _properties[1].PropertyId,
      Image = SeedImagesData.PropertyImages[1],
      ImageName = "bf86ccd4-8b41-417f-906c-8f85610e9085.webp",
      Enabled = true,
      CreatedAt = _properties[1].CreatedAt
    },
    new()
    {
      PropertyImageId = new("68ed98ea5e9a77cf7005835c"),
      PropertyId = _properties[2].PropertyId,
      Image = SeedImagesData.PropertyImages[2],
      ImageName = "56163b41-6d7d-46c8-a9b5-4eae28e9cef0.webp",
      Enabled = true,
      CreatedAt = _properties[2].CreatedAt
    },
    new()
    {
      PropertyImageId = new("68ed98ea5e9a77cf7005835d"),
      PropertyId = _properties[3].PropertyId,
      Image = SeedImagesData.PropertyImages[3],
      ImageName = "4e5a09b6-f580-4864-942d-369920e0574c.webp",
      Enabled = true,
      CreatedAt = _properties[3].CreatedAt
    },
    new()
    {
      PropertyImageId = new("68ed98ea5e9a77cf7005835e"),
      PropertyId = _properties[4].PropertyId,
      Image = SeedImagesData.PropertyImages[4],
      ImageName = "7648a047-13ba-4eea-b9ef-cd4f0c856de2.webp",
      Enabled = true,
      CreatedAt = _properties[4].CreatedAt
    }
  ];
}
