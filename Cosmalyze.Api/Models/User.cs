using Microsoft.AspNetCore.Identity;

namespace Cosmalyze.Api.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}