﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWebApi.Domain.Core.Entities
{
    public class UserRating
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        [Required]
        [Range(0,5)]
        public int Rating { get; set; }
    }
}
