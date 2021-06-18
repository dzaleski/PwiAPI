using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PwiAPI.Repositories;

namespace PwiAPI.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly CategoriesRepository _categoriesRepo;
        public CategoriesController(CategoriesRepository categoriesRepo)
        {
            _categoriesRepo = categoriesRepo;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllCategories() 
        {
            var categories = _categoriesRepo.GetAllCategories();
            return Ok(categories);
        }
    }
}
