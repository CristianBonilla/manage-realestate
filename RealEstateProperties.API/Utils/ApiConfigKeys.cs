namespace RealEstateProperties.API.Utils;

record struct ApiConfigKeys
{
  public const string AllowOrigins = nameof(AllowOrigins);
  public const string Bearer = nameof(Bearer);
  public const string DefaultDbConnection = nameof(DefaultDbConnection);
  public const string LocalDbConnection = nameof(LocalDbConnection);

  public static bool IsLocalDbPlatform => bool.Parse(Environment.GetEnvironmentVariable("LOCALDB_PLATFORM") ?? "false");
}
