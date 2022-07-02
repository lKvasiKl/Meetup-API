using System.ComponentModel.DataAnnotations;

namespace Meetup_API.Models.Request
{
    public class AuthRequest
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
