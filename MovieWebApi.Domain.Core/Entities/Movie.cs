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
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required field for movie")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public double? Rating { get; set; }
        public string Genre { get; set; }
    }
}