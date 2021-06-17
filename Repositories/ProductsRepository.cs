using Microsoft.EntityFrameworkCore;
using PwiAPI.Data;
using PwiAPI.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace PwiAPI.Repositories
{
    public class ProductsRepository
    {
        private readonly AppDbContext _context;
        public ProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<ProductDTO> GetAllProducts()
        {
            var products = _context.Products.Include(p => p.Category).ToList();

            var productsDto = new List<ProductDTO>();

            foreach (var item in products)
            {
                productsDto.Add(new ProductDTO()
                {
                    Id = item.Id,
                    ImageURL = item.ImageURL,
                    Category = new CategoryDTO()
                    {
                        Description = item.Category.Description,
                        Id = item.Category.Id,
                        Name = item.Category.Name
                    },
                    Description = item.Description,
                    Name =  item.Name,
                    Price = item.Price
                });
            }

            return productsDto;
        }
    }
}
