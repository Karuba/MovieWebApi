using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using MovieWebApi.Infrastructure.ML.DataModels;

namespace MovieWebApi.Infrastructure.ML
{
    public class MLRecommendation : IMLRecommendation
    {
        private readonly IConfiguration _configuration;

        public MLRecommendation(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ReBuild()
        {
            MLContext mlContext = new MLContext();
            IDataView data = LoadData(mlContext);

            var model = BuildAndTrainModel(mlContext, data);

            SaveModel(mlContext, data.Schema, model);

            //DataViewSchema modelSchema;

            //// Load trained model
            //ITransformer trainedModel = mlContext.Model.Load(Path.Combine(Environment.CurrentDirectory, "Data", "MovieRecommenderModel.zip"), out modelSchema);

            //UseModelForSinglePrediction(mlContext, trainedModel);
        }
        private IDataView LoadData(MLContext mlContext)
        {
            DatabaseLoader loader = mlContext.Data.CreateDatabaseLoader<MovieRating>();
            string connection = _configuration.GetConnectionString("SqlServer");
            string sqlCommand = _configuration.GetConnectionString("GetUserRatingData");

            DatabaseSource dbSource = new DatabaseSource(SqlClientFactory.Instance, connection, sqlCommand);

            IDataView data = loader.Load(dbSource);
            return data;
        }
        private ITransformer BuildAndTrainModel(MLContext mlContext, IDataView trainingDataView)
        {
            IEstimator<ITransformer> estimator = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: "UserId")
                .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "movieIdEncoded", inputColumnName: "MovieId"));

            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "userIdEncoded",
                MatrixRowIndexColumnName = "movieIdEncoded",
                LabelColumnName = "Rating",
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            var trainerEstimator = estimator.Append(mlContext.Recommendation().Trainers.MatrixFactorization(options));

            ITransformer model = trainerEstimator.Fit(trainingDataView);

            return model;
        }
        private void SaveModel(MLContext mlContext, DataViewSchema trainingDataViewSchema, ITransformer model)
        {
            var modelPath = Path.Combine(Environment.CurrentDirectory, "MLRModel", "MovieRecommenderModel.zip");

            mlContext.Model.Save(model, trainingDataViewSchema, modelPath);
        }
        private void UseModelForSinglePrediction(MLContext mlContext, ITransformer model)
        {
            var predictionEngine = mlContext.Model.CreatePredictionEngine<MovieRating, ModelOutput>(model);

            var testInput = new MovieRating { UserId = "379a3a5a-cf28-4808-9a9a-c63c82532faf", MovieId = "8e6e716c-a47c-4fac-9765-08dabb42e809" };
            var movieRatingPrediction = predictionEngine.Predict(testInput);

            if (movieRatingPrediction.Score > 3.5f)
            {
                Console.WriteLine("Movie " + testInput.MovieId + " is recommended for user " + testInput.UserId + $" Prediction: {movieRatingPrediction.Score}");
            }
            else
            {
                Console.WriteLine("Movie " + testInput.MovieId + " is not recommended for user " + testInput.UserId + $" Prediction: {movieRatingPrediction.Score}");
            }
        }
    }
}
