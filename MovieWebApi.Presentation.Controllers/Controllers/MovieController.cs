
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieWebApi.Contracts.Dto;
using MovieWebApi.Domain.Interfaces.RequestFeatures;
using MovieWebApi.Services.Interfaces;

namespace MovieWebApi.Presentation.Controllers.Controllers
{
    [ApiController]
    [Route("api/movie")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class MovieController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IHttpContextAccessor _httpContext;

        public MovieController(IServiceManager service, IHttpContextAccessor httpContext)
        {
            _serviceManager = service;
            _httpContext = httpContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetMoviesAsync([FromQuery] MovieParameters parameters)
        {
            var moviesDto = await _serviceManager.movieService.GetMoviesAsync(parameters);
            return Ok(moviesDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieAsync(Guid id)
        {
            var movieDto = await _serviceManager.movieService.GetMovieAsync(id);
            return Ok(movieDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovieAsync([FromBody] MovieCreateDto movieCreate)
        {
            var movieDto = await _serviceManager.movieService.CreateMovie(movieCreate);
            return Ok(movieDto); //CreatedAtRoute("Movie", new {id = movieDto.Id}, movieDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieAsync(Guid id)
        {
            await _serviceManager.movieService.DeleteMovie(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovieAsync(Guid id, [FromBody] MovieUpdateDto movieUpdate)
        {
            var movieDto = await _serviceManager.movieService.UpdateMovieAsync(id, movieUpdate);
            return Ok(movieDto); // CreatedAtRoute("Movie", new { id = movieDto.Id }, movieDto);
        }
        [HttpPost("{id}"), Authorize]
        public async Task<IActionResult> UpdateMovieRatingAsync(Guid id, [FromBody] UserRatingUpdateDto userRatingUpdate)
        {
            var movieDto = await _serviceManager.movieService.UpdateMovieRatingAsync(id, userRatingUpdate);
            return Ok(movieDto);
        }
        [HttpPost("{id}/{starringId}")]
        public async Task<IActionResult> AddMovieStarringAsync(Guid id, Guid starringId)
        {
            var movieDto = await _serviceManager.movieService.AddMovieStarringAsync(id, starringId);
            return Ok(movieDto);
        }
        [HttpDelete("{id}/{starringId}")]
        public async Task<IActionResult> DeleteMovieStarringAsync(Guid id, Guid starringId)
        {
            await _serviceManager.movieService.DeleteMovieStarringAsync(id, starringId);
            return NoContent();
        }
    }
}
