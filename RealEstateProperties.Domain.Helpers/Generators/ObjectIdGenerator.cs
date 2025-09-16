using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using MongoDB.Bson;

namespace RealEstateProperties.Domain.Helpers.Generators;

public class ObjectIdGenerator : ValueGenerator<ObjectId>
{
  public override ObjectId Next(EntityEntry entry) => ObjectId.GenerateNewId();

  public override bool GeneratesTemporaryValues => false;
}
