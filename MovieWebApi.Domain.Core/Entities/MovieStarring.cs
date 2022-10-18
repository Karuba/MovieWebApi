
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWebApi.Domain.Core.Entities
{
    public class MovieStarring
    {
        //[ForeignKey(nameof(Movie))]
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        //[ForeignKey(nameof(Starring))]
        public Guid StarringId { get; set; }
        public Starring Starring { get; set; }
    }
}
