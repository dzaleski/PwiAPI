using PwiAPI.Data;
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

        public List<Category> GetAllCategories()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }
    }
}
