using System.ComponentModel.DataAnnotations;

namespace PwiAPI.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
    }
}
