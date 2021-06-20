using System.ComponentModel.DataAnnotations;

namespace PwiAPI.Models
{
    public class Product : EntityBase
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        [Required]
        public string Description { get; set; }

        [MaxLength(255)]
        [Required]
        public string ImageURL { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public virtual Category Category { get; set; }
    }
}
