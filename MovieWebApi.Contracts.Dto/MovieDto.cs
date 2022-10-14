﻿
namespace MovieWebApi.Contracts.Dto
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double? Rating { get; set; }
        public string Genre { get; set; }
    }
}