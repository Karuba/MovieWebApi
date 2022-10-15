
using Microsoft.AspNetCore.Mvc;
using MovieWebApi.Contracts.Dto;
using MovieWebApi.Domain.Interfaces.RequestFeatures;
using MovieWebApi.Services.Interfaces;

namespace MovieWebApi.Presentation.Controllers.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public MovieController(IServiceManager service) => _serviceManager = service;

        [HttpGet]
        public async Task<IActionResult> GetMoviesAsync([FromQuery]MovieParameters parameters)
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
        public async Task<IActionResult> DeleteMovieasync(Guid id)
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
    }
}
