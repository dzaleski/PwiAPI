using System.ComponentModel.DataAnnotations;

namespace PwiAPI.DTOs
{
    public class UserLoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
