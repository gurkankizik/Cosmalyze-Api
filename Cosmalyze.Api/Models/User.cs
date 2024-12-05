using Microsoft.AspNetCore.Identity;

namespace Cosmalyze.Api.Models
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Phone { get; set; }
       
    }
}