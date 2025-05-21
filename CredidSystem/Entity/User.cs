using Microsoft.AspNetCore.Identity;

namespace CredidSystem.Entity
{
    public class User : IdentityUser
    {
        public string LoginIpAdr { get; set; }

       
    }
}
