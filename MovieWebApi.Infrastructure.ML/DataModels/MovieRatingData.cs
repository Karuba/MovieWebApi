
using Microsoft.ML.Data;

namespace MovieWebApi.Infrastructure.ML.DataModels
{
    public class MovieRating
    {
        [ColumnName(@"UserId")]
        public string UserId { get; set; }

        [ColumnName(@"MovieId")]
        public string MovieId { get; set; }

        [ColumnName(@"Rating")]
        public Single Rating { get; set; }
    }
    public class ModelOutput
    {
        public float Score { get; set; }
    }
    public class MovieRatingDto
    {
        public string UserId { get; set; }
        public string MovieId { get; set; }
    }
}
