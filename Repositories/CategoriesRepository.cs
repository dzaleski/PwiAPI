using PwiAPI.Data;
using PwiAPI.DTOs;
using PwiAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PwiAPI.Repositories
{
    public class CategoriesRepository
    {
        private readonly AppDbContext _context;

        public CategoriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<CategoryDTO> GetAllCategories()
        {
            var categories = _context.Categories.ToList();

            var categoriesDTO = new List<CategoryDTO>();

            foreach (Category c in categories)
            {
                categoriesDTO.Add(new CategoryDTO
                {
                    Description = c.Description,
                    Id = c.Id,
                    Name = c.Name
                });
            }

            return categoriesDTO;
        }
    }
}
