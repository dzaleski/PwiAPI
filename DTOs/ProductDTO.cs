using PwiAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace PwiAPI.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
