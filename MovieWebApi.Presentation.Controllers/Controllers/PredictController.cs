using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using MLRModel;
using MovieWebApi.Infrastructure.ML;
using MovieWebApi.Infrastructure.ML.DataModels;

namespace MovieWebApi.Presentation.Controllers.Controllers
{
    [ApiController]
    [Route("api/predict")]
    public class PredictController : ControllerBase
    {
        private readonly PredictionEnginePool<MovieRating, ModelOutput> _predictionEnginePool;
        private readonly IMLRecommendation _mlRecommendation;

        public PredictController(PredictionEnginePool<MovieRating, ModelOutput> predictionEnginePool, IMLRecommendation mlRecommendation)
        {
            _predictionEnginePool = predictionEnginePool;
            _mlRecommendation = mlRecommendation;
        }

        [HttpPost]
        public async Task<IActionResult> UserRatingPredict([FromBody] MovieRating input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ModelOutput prediction = await Task.FromResult(_predictionEnginePool.Predict(input));

            string sentiment = prediction.Score.ToString();

            return Ok(sentiment);
        }
        [HttpPut]
        public IActionResult PredicModelRebuild()
        {
            _mlRecommendation.ReBuild();
            return Ok();
        }
    }
}
