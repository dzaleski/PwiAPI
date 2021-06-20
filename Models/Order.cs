using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PwiAPI.Models
{
    public class Order : EntityBase
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public virtual User User { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
