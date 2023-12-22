using EFCore.Data;
using EFCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        //Dependency Injection (Constructor Injection)
        public CategoriesController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categories = _context.Categories.ToList();

            return Ok(categories);

        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if(category == null)
            {
                return NotFound();
            }

            return Ok(category);

        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return Ok(category);

        }
    }
}
