using Microsoft.AspNetCore.Identity;

namespace CredidSystem.Entity
{
    public abstract  class User : IdentityUser
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
    }
}
