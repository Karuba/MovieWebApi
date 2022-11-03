
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWebApi.Domain.Core.Entities
{
    public class MovieStarring
    {
        public string MovieId { get; set; }
        public Movie Movie { get; set; }
        public string StarringId { get; set; }
        public Starring Starring { get; set; }
    }
}
