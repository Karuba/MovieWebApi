
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MovieWebApi.Domain.Core.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<UserRating> UserRatings { get; set; }
    }
}
