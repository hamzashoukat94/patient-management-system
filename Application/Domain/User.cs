using Microsoft.AspNetCore.Identity;

namespace Application.Domain
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
