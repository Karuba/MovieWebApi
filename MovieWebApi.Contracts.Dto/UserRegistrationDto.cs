
using System.ComponentModel.DataAnnotations;

namespace MovieWebApi.Contracts.Dto
{
    public class UserRegistrationDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        //public ICollection<string> Roles { get; set; }
    }
}
