
using System.ComponentModel.DataAnnotations;

namespace MovieWebApi.Contracts.Dto
{
    public class UserDto
    {
        public string UserName { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
