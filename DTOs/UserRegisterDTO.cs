using System.ComponentModel.DataAnnotations;

namespace PwiAPI.DTOs
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "This isn't email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
                 ErrorMessage = "Password must be at least 8 characters with one letter, one digit and one special character!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repeated password is required!")]
        [Compare(nameof(Password), ErrorMessage = "Passwords doesn't match!")]
        public string RepeatPassword { get; set; }
    }
}
