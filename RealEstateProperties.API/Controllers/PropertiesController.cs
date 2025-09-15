using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using RealEstateProperties.API.Filters;
using RealEstateProperties.API.Utils;
using RealEstateProperties.Contracts.Mongo.DTO.Properties;
using RealEstateProperties.Contracts.Mongo.Services;
using RealEstateProperties.Domain.Entities.Mongo;

namespace RealEstateProperties.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ServiceErrorExceptionFilter]
public class PropertiesController(IMapper mapper, IPropertiesService propertiesService) : ControllerBase
{
  readonly IMapper _mapper = mapper;
  readonly IPropertiesService _propertiesService = propertiesService;

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PropertyResponse))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> AddProperty([FromBody] PropertyRequest propertyRequest)
  {
    PropertyEntity property = _mapper.Map<PropertyEntity>(propertyRequest);
    PropertyEntity addedProperty = await _propertiesService.AddProperty(property);
    PropertyResponse propertyResponse = _mapper.Map<PropertyResponse>(addedProperty);

    return CreatedAtAction(nameof(AddProperty), propertyResponse);
  }

  [HttpPut("{propertyId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertyResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> UpdateProperty(string propertyId, [FromBody] PropertyRequest propertyRequest)
  {
    if (!ObjectId.TryParse(propertyId, out ObjectId propertyIdValue))
      return StatusCode(StatusCodes.Status400BadRequest, $"Invalid identifier {propertyId} to search for the property");
    PropertyEntity property = await _propertiesService.FindPropertyById(propertyIdValue);
    PropertyEntity updatedProperty = _mapper.Map(propertyRequest, property);
    PropertyResponse propertyResponse = await UpdateProperty(propertyIdValue, updatedProperty);

    return Ok(propertyResponse);
  }

  [HttpDelete("{propertyId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertyResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> DeleteProperty(string propertyId)
  {
    if (!ObjectId.TryParse(propertyId, out ObjectId propertyIdValue))
      return StatusCode(StatusCodes.Status400BadRequest, $"Invalid identifier {propertyId} to search for the property");
    PropertyEntity property = await _propertiesService.DeleteProperty(propertyIdValue);

    return Ok(_mapper.Map<PropertyResponse>(property));
  }

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<PropertiesResult>))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public IAsyncEnumerable<PropertiesResult> GetProperties()
    => _mapper.Map<IAsyncEnumerable<PropertiesResult>>(_propertiesService.GetProperties());

  [HttpGet("{text}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<PropertiesResult>))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public IAsyncEnumerable<PropertiesResult> GetProperties(string text)
    => _mapper.Map<IAsyncEnumerable<PropertiesResult>>(_propertiesService.GetProperties(text));

  [HttpPut("price/{propertyId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertyResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> ChangePropertyPrice(string propertyId, [FromQuery] decimal price)
  {
    if (!ObjectId.TryParse(propertyId, out ObjectId propertyIdValue))
      return StatusCode(StatusCodes.Status400BadRequest, $"Invalid identifier {propertyId} to search for the property");
    PropertyEntity property = await _propertiesService.FindPropertyById(propertyIdValue);
    property.Price = price;
    PropertyResponse propertyResponse = await UpdateProperty(propertyIdValue, property);

    return Ok(propertyResponse);
  }

  [HttpPost("images/{propertyId}")]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PropertyImageResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> AddPropertyImage(string propertyId, IFormFile image)
  {
    if (!ObjectId.TryParse(propertyId, out ObjectId propertyIdValue))
      return StatusCode(StatusCodes.Status400BadRequest, $"Invalid identifier {propertyId} to search for the property");
    if (image.Length <= 0)
      return StatusCode(StatusCodes.Status400BadRequest, "There is no property image to process");
    byte[] imageBytes = await ImageStreamUtils.GetImageBytes(image);
    PropertyImageEntity propertyImage = await _propertiesService.AddPropertyImage(propertyIdValue, imageBytes, image.FileName);
    PropertyImageResponse propertyImageResponse = _mapper.Map<PropertyImageResponse>(propertyImage);

    return CreatedAtAction(nameof(AddPropertyImage), propertyImageResponse);
  }

  [HttpPut("images")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertyImageResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> UpdatePropertyImage([FromQuery] string propertyId, [FromQuery] string propertyImageId, IFormFile image)
  {
    if (!ObjectId.TryParse(propertyId, out ObjectId propertyIdValue))
      return StatusCode(StatusCodes.Status400BadRequest, $"Invalid identifier {propertyId} to search for the property");
    if (!ObjectId.TryParse(propertyImageId, out ObjectId propertyImageIdValue))
      return StatusCode(StatusCodes.Status400BadRequest, $"Invalid identifier {propertyImageId} to search for the property image");
    if (image.Length <= 0)
      return StatusCode(StatusCodes.Status400BadRequest, "There is no property image to process");
    byte[] imageBytes = await ImageStreamUtils.GetImageBytes(image);
    PropertyImageEntity propertyImage = await _propertiesService.UpdatePropertyImage(propertyIdValue, propertyImageIdValue, imageBytes, image.FileName);
    PropertyImageResponse propertyImageResponse = _mapper.Map<PropertyImageResponse>(propertyImage);

    return Ok(propertyImageResponse);
  }

  [HttpDelete("images")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertyImageResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> DeletePropertyImage([FromQuery] string propertyId, [FromQuery] string propertyImageId)
  {
    if (!ObjectId.TryParse(propertyId, out ObjectId propertyIdValue))
      return StatusCode(StatusCodes.Status400BadRequest, $"Invalid identifier {propertyId} to search for the property");
    if (!ObjectId.TryParse(propertyImageId, out ObjectId propertyImageIdValue))
      return StatusCode(StatusCodes.Status400BadRequest, $"Invalid identifier {propertyImageId} to search for the property image");
    PropertyImageEntity propertyImage = await _propertiesService.DeletePropertyImage(propertyIdValue, propertyImageIdValue);
    PropertyImageResponse propertyImageResponse = _mapper.Map<PropertyImageResponse>(propertyImage);

    return Ok(propertyImageResponse);
  }

  [HttpGet("images/{propertyId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PropertyImageResponse>))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public IActionResult GetPropertyImages(string propertyId)
  {
    if (!ObjectId.TryParse(propertyId, out ObjectId propertyIdValue))
      return StatusCode(StatusCodes.Status400BadRequest, $"Invalid identifier {propertyId} to search for the property");
    var (_, propertyImages) = _propertiesService.GetPropertyImages(propertyIdValue);

    return Ok(propertyImages.Select(_mapper.Map<PropertyImageResponse>));
  }

  [HttpGet("images/{propertyId}/files")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileContentResult))]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> GetPropertyImagesFiles(string propertyId)
  {
    if (!ObjectId.TryParse(propertyId, out ObjectId propertyIdValue))
      return StatusCode(StatusCodes.Status400BadRequest, $"Invalid identifier {propertyId} to search for the property");
    var (propertyName, propertyImages) = _propertiesService.GetPropertyImages(propertyIdValue);
    if (await ImageStreamUtils.GetImagesBytes(propertyName, propertyImages) is var (imageBytes, contentType, imageName))
      return File(imageBytes, contentType, imageName);

    return StatusCode(StatusCodes.Status400BadRequest, $"There are no images to process");
  }

  [HttpPost("traces")]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PropertyTraceResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> AddPropertyTrace([FromBody] PropertyTraceRequest propertyTraceRequest)
  {
    PropertyTraceEntity propertyTrace = _mapper.Map<PropertyTraceEntity>(propertyTraceRequest);
    PropertyTraceEntity addedPropertyTrace = await _propertiesService.AddPropertyTrace(propertyTrace);
    PropertyTraceResponse propertyTraceResponse = _mapper.Map<PropertyTraceResponse>(addedPropertyTrace);

    return Ok(propertyTraceResponse);
  }

  [HttpGet("traces/{propertyId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PropertyTraceResponse>))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> GetPropertyTraces(string propertyId)
  {
    if (!ObjectId.TryParse(propertyId, out ObjectId propertyIdValue))
      return StatusCode(StatusCodes.Status400BadRequest, $"Invalid identifier {propertyId} to search for the property");
    var propertyTraces = await _propertiesService.GetPropertyTraces(propertyIdValue)
      .Select(_mapper.Map<PropertyTraceResponse>)
      .ToArrayAsync();

    return Ok(propertyTraces);
  }

  private async Task<PropertyResponse> UpdateProperty(ObjectId propertyId, PropertyEntity property)
  {
    PropertyEntity updatedProperty = await _propertiesService.UpdateProperty(propertyId, property);
    PropertyResponse propertyResponse = _mapper.Map<PropertyResponse>(updatedProperty);
    propertyResponse.PropertyTraces = await _propertiesService.GetPropertyTraces(propertyId)
      .Select(_mapper.Map<PropertyTraceResponse>)
      .ToArrayAsync();

    return propertyResponse;
  }
}
