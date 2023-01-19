using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWebApi.Domain.Core.Entities
{
    [Table("Movie")]
    public class Movie
    {
        [Column("MovieId")]
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "The Name is required field for movie")]
        [MinLength(1, ErrorMessage = "The Name must contain at least 1 character"), MaxLength(250, ErrorMessage = "The Name mustn't exceed 250 characters")]
        public string Name { get; set; }
        [MaxLength(500, ErrorMessage = "The Description mustn't exceed 500 characters")]
        public string? Description { get; set; }
        [Range(0,5, ErrorMessage = "The Rating must contain integer values in the range from 0 to 5 ")]
        public double? Rating { get; set; }
        [MaxLength(500, ErrorMessage = "The ImagePath mustn't exceed 500 characters")]
        public string? Image { get; set; }
        public ICollection<MovieStarring> MovieStarrings { get; set; } = new List<MovieStarring>();
        public ICollection<UserRating> UserRatings { get; set; }
    }
}