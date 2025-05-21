using System.ComponentModel.DataAnnotations;

namespace CredidSystem.Areas.Admin.Models
{
    public class SignInViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
