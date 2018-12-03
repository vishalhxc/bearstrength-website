using Microsoft.AspNetCore.Identity;

namespace Bearstrength.Models
{
    public class BearstrengthUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
