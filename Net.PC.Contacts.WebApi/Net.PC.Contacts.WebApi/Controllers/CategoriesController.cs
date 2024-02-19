using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net.PC.Contacts.Repository.Repository;

namespace Net.PC.Contacts.WebApi.Controllers
{
    [Route("api/categories")]
    [Authorize]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var result = _categoryRepository.GetAll();

            return Ok(result);
        }
    }
}
