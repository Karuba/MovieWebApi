using System.ComponentModel.DataAnnotations;

namespace MovieWebApi.Contracts.Dto
{
    public class StarringUpdateDto
    {
        [Required(ErrorMessage = "The FirstName is required field for starring")]
        [MinLength(1, ErrorMessage = "The FirstName must contain at least 1 character"), MaxLength(80, ErrorMessage = "The FirstName mustn't exceed 80 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The SecondName is required field for starring")]
        [MinLength(1, ErrorMessage = "The SecondName must contain at least 1 character"), MaxLength(80, ErrorMessage = "The SecondName mustn't exceed 80 characters")]
        public string SecondName { get; set; }
        [MaxLength(500, ErrorMessage = "The Description mustn't exceed 500 characters")]
        public string? Description { get; set; }
    }
}
