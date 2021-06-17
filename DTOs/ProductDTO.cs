using PwiAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace PwiAPI.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "URL is required.")]
        public string Name { get; set; }
        public int Price { get; set; }

        [Required(ErrorMessage = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "URL is required.")]
        [Url(ErrorMessage = "This isn't valid URL.")]
        public string ImageURL { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
