using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore.Extensions;
using RealEstateProperties.Contracts.Mongo.SeedData;
using RealEstateProperties.Domain.Entities.Mongo;
using RealEstateProperties.Domain.Helpers.Generators;

namespace RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties.Config;

class OwnerConfig(ISeedData? seedData = null) : IEntityTypeConfiguration<OwnerEntity>
{
  public void Configure(EntityTypeBuilder<OwnerEntity> builder)
  {
    builder.ToCollection("owner")
      .HasKey(key => key.OwnerId);
    builder.Property(property => property.OwnerId)
      .HasValueGenerator<ObjectIdGenerator>()
      .ValueGeneratedOnAdd();
    builder.Property(property => property.Name)
      .HasElementName("name")
      .IsRequired();
    builder.Property(property => property.Address)
      .HasElementName("address")
      .IsRequired();
    builder.Property(property => property.Photo)
      .HasElementName("photo");
    builder.Property(property => property.PhotoName)
      .HasElementName("photoName");
    builder.Property(property => property.Birthday)
      .HasElementName("birthday")
      .IsRequired();
    builder.Property(property => property.CreatedAt)
      .HasElementName("createdAt")
      .HasValueGenerator<DateTimeOffsetNowGenerator>()
      .ValueGeneratedOnAdd();
    builder.Property(property => property.UpdatedAt)
      .HasElementName("updatedAt")
      .HasValueGenerator<DateTimeOffsetNowGenerator>()
      .ValueGeneratedOnAddOrUpdate();
    builder.Property(property => property.Version)
      .HasElementName("version")
      .IsRowVersion();
    builder.HasIndex(index => index.Name)
      .IsUnique();
    if (seedData is not null)
      builder.HasData(seedData.RealEstateProperties.Owners.GetAll());
  }
}

class PropertyConfig(ISeedData? seedData = null) : IEntityTypeConfiguration<PropertyEntity>
{
  public void Configure(EntityTypeBuilder<PropertyEntity> builder)
  {
    builder.ToCollection("property")
      .HasKey(key => key.PropertyId);
    builder.Property(property => property.PropertyId)
      .HasValueGenerator<ObjectIdGenerator>()
      .ValueGeneratedOnAdd();
    builder.Property(property => property.OwnerId)
      .HasElementName("ownerId")
      .IsRequired();
    builder.Property(property => property.Name)
      .HasElementName("name")
      .IsRequired();
    builder.Property(property => property.Address)
      .HasElementName("address")
      .IsRequired();
    builder.Property(property => property.Price)
      .HasElementName("price")
      .HasBsonRepresentation(BsonType.Decimal128)
      .IsRequired();
    builder.Property(property => property.CodeInternal)
      .HasElementName("codeInternal")
      .IsRequired();
    builder.Property(property => property.Year)
      .HasElementName("year")
      .IsRequired();
    builder.Property(property => property.CreatedAt)
      .HasElementName("createdAt")
      .HasValueGenerator<DateTimeOffsetNowGenerator>()
      .ValueGeneratedOnAdd();
    builder.Property(property => property.UpdatedAt)
      .HasElementName("updatedAt")
      .HasValueGenerator<DateTimeOffsetNowGenerator>()
      .ValueGeneratedOnAddOrUpdate();
    builder.Property(property => property.Version)
      .HasElementName("version")
      .IsRowVersion();
    builder.HasIndex(index => new { index.Name, index.CodeInternal })
      .IsUnique();
    if (seedData is not null)
      builder.HasData(seedData.RealEstateProperties.Properties.GetAll());
  }
}

class PropertyImageConfig(ISeedData? seedData = null) : IEntityTypeConfiguration<PropertyImageEntity>
{
  public void Configure(EntityTypeBuilder<PropertyImageEntity> builder)
  {
    builder.ToCollection("propertyImage")
      .HasKey(key => key.PropertyImageId);
    builder.Property(property => property.PropertyImageId)
      .HasValueGenerator<ObjectIdGenerator>()
      .ValueGeneratedOnAdd();
    builder.Property(property => property.PropertyId)
      .HasElementName("propertyId")
      .IsRequired();
    builder.Property(property => property.Image)
      .HasElementName("image")
      .IsRequired();
    builder.Property(property => property.ImageName)
      .HasElementName("imageName")
      .IsRequired();
    builder.Property(property => property.Enabled)
      .HasElementName("enabled")
      .IsRequired();
    builder.Property(property => property.CreatedAt)
      .HasElementName("createdAt")
      .HasValueGenerator<DateTimeOffsetNowGenerator>()
      .ValueGeneratedOnAdd();
    builder.Property(property => property.UpdatedAt)
      .HasElementName("updatedAt")
      .HasValueGenerator<DateTimeOffsetNowGenerator>()
      .ValueGeneratedOnAddOrUpdate();
    builder.Property(property => property.Version)
      .HasElementName("version")
      .IsRowVersion();
    builder.HasIndex(index => index.ImageName)
      .IsUnique();
    if (seedData is not null)
      builder.HasData(seedData.RealEstateProperties.PropertyImages.GetAll());
  }
}

class PropertyTraceConfig(ISeedData? seedData = null) : IEntityTypeConfiguration<PropertyTraceEntity>
{
  public void Configure(EntityTypeBuilder<PropertyTraceEntity> builder)
  {
    builder.ToCollection("propertyTrace")
      .HasKey(key => key.PropertyTraceId);
    builder.Property(property => property.PropertyTraceId)
      .HasValueGenerator<ObjectIdGenerator>()
      .ValueGeneratedOnAdd();
    builder.Property(property => property.PropertyId)
      .HasElementName("propertyId")
      .IsRequired();
    builder.Property(property => property.Name)
      .HasElementName("name")
      .IsRequired();
    builder.Property(property => property.Value)
      .HasElementName("value")
      .HasBsonRepresentation(BsonType.Decimal128)
      .IsRequired();
    builder.Property(property => property.Tax)
      .HasElementName("tax")
      .HasBsonRepresentation(BsonType.Decimal128)
      .IsRequired();
    builder.Property(property => property.DateSale)
      .HasElementName("dateSale")
      .IsRequired();
    builder.Property(property => property.CreatedAt)
      .HasElementName("createdAt")
      .HasValueGenerator<DateTimeOffsetNowGenerator>()
      .ValueGeneratedOnAdd();
    builder.Property(property => property.UpdatedAt)
      .HasElementName("updatedAt")
      .HasValueGenerator<DateTimeOffsetNowGenerator>()
      .ValueGeneratedOnAddOrUpdate();
    builder.Property(property => property.Version)
      .HasElementName("version")
      .IsRowVersion();
    builder.HasIndex(index => index.Name)
      .IsUnique();
    if (seedData is not null)
      builder.HasData(seedData.RealEstateProperties.PropertyTraces.GetAll());
  }
}
