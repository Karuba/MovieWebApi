using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWebApi.Domain.Core.Entities
{
    [Table("Starring")]
    public class Starring
    {
        [Column("StarringId")]
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "The FirstName is required field for starring")]
        [MinLength(1, ErrorMessage = "The FirstName must contain at least 1 character"), MaxLength(80, ErrorMessage = "The FirstName mustn't exceed 80 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The SecondName is required field for starring")]
        [MinLength(1, ErrorMessage = "The SecondName must contain at least 1 character"), MaxLength(80, ErrorMessage = "The SecondName mustn't exceed 80 characters")]
        public string SecondName { get; set; }
        [MaxLength(500, ErrorMessage = "The Description mustn't exceed 500 characters")]
        public string? Description { get; set; }
        public ICollection<MovieStarring> MovieStarrings { get; set; }
    }
}