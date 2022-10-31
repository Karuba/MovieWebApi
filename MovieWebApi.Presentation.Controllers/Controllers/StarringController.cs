
using Microsoft.AspNetCore.Mvc;
using MovieWebApi.Contracts.Dto;
using MovieWebApi.Domain.Interfaces.RequestFeatures;
using MovieWebApi.Services.Interfaces;

namespace MovieWebApi.Presentation.Controllers.Controllers
{
    [ApiController]
    [Route("api/starring")]
    public class StarringController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public StarringController(IServiceManager service) => _serviceManager = service;

        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetStarringsAsync(Guid movieId, [FromQuery] StarringParameters parameters)
        {
            var starringsDto = await _serviceManager.starringService.GetStarringsAsync(movieId, parameters);
            return Ok(starringsDto);
        }
        [HttpPost("{movieId}")]
        public async Task<IActionResult> CreateStarringAsync(Guid movieId, [FromBody] StarringCreateDto starringCreateDto)
        {
            var starringDto = await _serviceManager.starringService.CreateStarring(movieId, starringCreateDto);
            return Ok(starringDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStarringAsync(Guid id, [FromBody] StarringUpdateDto starringUpdateDto)
        {
            var starringDto = await _serviceManager.starringService.UpdateStarringAsync(id, starringUpdateDto);
            return Ok(starringDto); // CreatedAtRoute("Movie", new { id = movieDto.Id }, movieDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStarringAsync(Guid id)
        {
            await _serviceManager.starringService.DeleteStarring(id);
            return NoContent();
        }
    }
}
