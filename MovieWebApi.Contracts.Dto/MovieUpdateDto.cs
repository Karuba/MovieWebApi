using System.ComponentModel.DataAnnotations;

namespace MovieWebApi.Contracts.Dto
{
    public class MovieUpdateDto
    {
        [Required(ErrorMessage = "Name is required field for movie")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public double? Rating { get; set; }
    }
}
