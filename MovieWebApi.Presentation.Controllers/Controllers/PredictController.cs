using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using MLRModel;
using MovieWebApi.Infrastructure.ML.DataModels;

namespace MovieWebApi.Presentation.Controllers.Controllers
{
    [ApiController]
    [Route("api/predict")]
    public class PredictController : ControllerBase
    {
        private readonly PredictionEnginePool<MLRecommendationModel.ModelInput, MLRecommendationModel.ModelOutput> _predictionEnginePool;

        public PredictController(PredictionEnginePool<MLRecommendationModel.ModelInput, MLRecommendationModel.ModelOutput> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MLRecommendationModel.ModelInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            MLRecommendationModel.ModelOutput prediction = await Task.FromResult(_predictionEnginePool.Predict(input));

            string sentiment = prediction.Score.ToString();

            return Ok(sentiment);
        }
    }
}
