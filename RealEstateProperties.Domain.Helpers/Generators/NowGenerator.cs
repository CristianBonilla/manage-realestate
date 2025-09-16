using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace RealEstateProperties.Domain.Helpers.Generators;

public class DateTimeNowGenerator : ValueGenerator<DateTime>
{
  public override DateTime Next(EntityEntry entry) => DateTime.UtcNow;

  public override bool GeneratesTemporaryValues => false;
}

public class DateTimeOffsetNowGenerator : ValueGenerator<DateTimeOffset>
{
  public override DateTimeOffset Next(EntityEntry entry) => DateTimeOffset.UtcNow;

  public override bool GeneratesTemporaryValues => false;
}
