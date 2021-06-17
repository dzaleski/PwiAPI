using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PwiAPI.Models
{
    public class Category : EntityBase
    {

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
