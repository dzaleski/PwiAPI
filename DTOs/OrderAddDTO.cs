using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PwiAPI.DTOs
{
    public class OrderAddDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{2}-[0-9]{3}$",
         ErrorMessage = "Invalid zip code!")]
        public string ZipCode { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        public IEnumerable<OrderProductDTO> products { get; set; }
    }
}
