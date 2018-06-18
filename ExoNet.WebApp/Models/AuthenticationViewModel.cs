using System.ComponentModel.DataAnnotations;

namespace ExoNet.WebApp.Models
{
    public class AuthenticationViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsConfidential { get; set; }
    }
}
