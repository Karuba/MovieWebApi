using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using MovieWebApi.Domain.Interfaces.Exceptions;
using MovieWebApi.Domain.Interfaces.RequestFeatures;
using MovieWebApi.Infrastructure.ML;
using MovieWebApi.Infrastructure.ML.DataModels;
using MovieWebApi.Services.Interfaces;
using MovieWebApi.Services.Interfaces.Authentication;

namespace MovieWebApi.Presentation.Controllers.Controllers
{
    [ApiController]
    [Route("api/predict")]
    public class PredictController : ControllerBase
    {
        private readonly IMLRecommendation _mlRecommendation;
        private readonly IServiceManager _serviceManager;
        private readonly IAuthenticationManager _authenticationManager;

        public PredictController(IMLRecommendation mlRecommendation, IServiceManager serviceManager, IAuthenticationManager authenticationManager)
        {
            _mlRecommendation = mlRecommendation;
            _serviceManager = serviceManager;
            _authenticationManager = authenticationManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRatingPredict([FromBody] UserRecommendationParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //ModelOutput prediction = await Task.FromResult(_predictionEnginePool.Predict(input));
            //return Ok(prediction.Score.ToString());

            var user = await _authenticationManager.GetUserAsync(parameters.UserName);
            if (user is null)
                throw new NotFoundException($"user {parameters.UserName} doesn't exist");

            var movies = await _serviceManager.predictService.GetUserRecommendation(user);
            return Ok(movies);

        }
        [HttpPut]
        public IActionResult PredicModelRebuild()
        {
            _mlRecommendation.ReBuild();
            return Ok();
        }
    }
}
