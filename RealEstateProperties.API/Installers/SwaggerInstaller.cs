using System.Reflection;
using Microsoft.OpenApi.Models;
using RealEstateProperties.API.Filters;
using RealEstateProperties.API.Options;
using RealEstateProperties.API.Utils;
using RealEstateProperties.Contracts.Enums;
using RealEstateProperties.Domain.Helpers;

namespace RealEstateProperties.API.Installers;

class SwaggerInstaller : IInstaller
{
  public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
  {
    IConfigurationSection swaggerSection = configuration.GetSection(nameof(SwaggerOptions));
    services.Configure<SwaggerOptions>(swaggerSection);
    SwaggerOptions swagger = swaggerSection.Get<SwaggerOptions>()!;
    OpenApiInfo info = swagger.Info;
    services.AddSwaggerGen(options =>
    {
      options.SwaggerDoc(info.Version, info);
      options.SchemaFilter<EnumSchemaFilter>();
      if (swagger?.SecurityScheme is not null)
      {
        OpenApiSecurityScheme apiSecurity = swagger.SecurityScheme;
        apiSecurity.Reference = new()
        {
          Id = ApiConfigKeys.Bearer,
          Type = ReferenceType.SecurityScheme
        };
        options.AddSecurityDefinition(ApiConfigKeys.Bearer, apiSecurity);
        options.AddSecurityRequirement(new() { { apiSecurity, new List<string>() } });
      }
      string xmlCommentsFilePath = DirectoryConfigHelper.GetDirectoryFilePathFromAssemblyName(FileFormatTypes.Xml, Assembly.GetExecutingAssembly());
      options.IncludeXmlComments(xmlCommentsFilePath, true);
    });
  }
}
