using Business;
using Business.Models;
using DataAccess.Repository;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreApiCategories.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryBusiness> _logger;

        public CategoriesController(ICategoryRepository categoryRepository, ILogger<CategoryBusiness> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await new CategoryBusiness(_categoryRepository, _logger).GetCategories();
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryAddDto>> Get(int id)
        {
            CategoryAddDto categoryDto = await new CategoryBusiness(_categoryRepository, _logger)
                .GetCategoryById(id);

            if (categoryDto == null)
            {
                return NotFound();
            }

            return categoryDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryAddDto categoryAdd)
        {
            Category categ = await new CategoryBusiness(_categoryRepository, _logger)
                .AddCategory(categoryAdd);

            if (categ != null)
            {
                return new CreatedAtRouteResult("GetCategory", new { id = categ.CategoryId }, categ);
            }
            else
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
