using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PwiAPI.DTOs;
using PwiAPI.Repositories;

namespace PwiAPI.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly ProductsRepository _productRepo;
        public ProductsController(ProductsRepository productRepository)
        {
            _productRepo = productRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productRepo.GetAllProducts();
            return Ok(products);
        }
    }
}
