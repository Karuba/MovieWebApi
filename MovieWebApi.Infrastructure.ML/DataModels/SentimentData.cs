﻿using Microsoft.ML.Data;

namespace MovieWebApi.MLModels.DataModels
{
    public class SentimentData
    {
        [LoadColumn(0)]
        public string SentimentText;

        [LoadColumn(1)]
        [ColumnName("Label")]
        public bool Sentiment;
    }
}
