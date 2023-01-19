
using Microsoft.AspNetCore.Identity;

namespace MovieWebApi.Domain.Core.Entities
{
    public class User : IdentityUser
    {
        public ICollection<UserRating> UserRatings { get; set; }
    }
}
