
using System.ComponentModel.DataAnnotations;

namespace MovieWebApi.Contracts.Dto
{
    public class UserRatingUpdateDto
    {
        [Required]
        [Range(0, 5, ErrorMessage = "The Rating must contain integer values in the range from 0 to 5 ")]
        public int Rating { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
