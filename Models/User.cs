using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PwiAPI.Models
{
    public class User : EntityBase
    {

        [MaxLength(255)]
        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        public float AccountBalance { get; set; }

        public IEnumerable<Order> Orders { get; set; }

    }
}
