
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MovieWebApi.Domain.Core.Entities
{
    public class User : IdentityUser
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
