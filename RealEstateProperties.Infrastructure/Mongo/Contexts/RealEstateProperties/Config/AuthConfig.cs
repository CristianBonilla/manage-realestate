using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using RealEstateProperties.Contracts.Mongo.SeedData;
using RealEstateProperties.Domain.Entities.Mongo.Auth;
using RealEstateProperties.Domain.Helpers.Generators;

namespace RealEstateProperties.Infrastructure.Mongo.Contexts.RealEstateProperties.Config;

class UserConfig(ISeedData? seedData = null) : IEntityTypeConfiguration<UserEntity>
{
  public void Configure(EntityTypeBuilder<UserEntity> builder)
  {
    builder.ToCollection("user")
      .HasKey(key => key.UserId);
    builder.Property(property => property.UserId)
      .HasValueGenerator<ObjectIdGenerator>()
      .ValueGeneratedOnAdd();
    builder.Property(property => property.DocumentNumber)
      .HasElementName("documentNumber")
      .IsRequired();
    builder.Property(property => property.Mobile)
      .HasElementName("mobile")
      .IsRequired();
    builder.Property(property => property.Username)
      .HasElementName("username")
      .IsRequired();
    builder.Property(property => property.Password)
      .HasElementName("password")
      .IsRequired();
    builder.Property(property => property.Email)
      .HasElementName("email")
      .IsRequired();
    builder.Property(property => property.Firstname)
      .HasElementName("firstname")
      .IsRequired();
    builder.Property(property => property.Lastname)
      .HasElementName("lastname")
      .IsRequired();
    builder.Property(property => property.IsActive)
      .HasElementName("isActive")
      .IsRequired();
    builder.Property(property => property.Salt)
      .HasElementName("salt")
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
    builder.HasIndex(index => new { index.DocumentNumber, index.Username, index.Email, index.Mobile })
      .IsUnique();
    if (seedData is not null)
      builder.HasData(seedData.Auth.Users.GetAll());
  }
}
