using EFCore2.Data;
using EFCore2.DTOs;
using EFCore2.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly DatabaseContext _context;

    //Dependency Injection -> Constructor Injection
    public ProductsController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // select * from products
        // select Name, Price from products


        var products = await _context.Products //select * from Products
            .Include(p => p.Category) // inner join Categories as c on p.CategoryId = c.Id
            .Select(p => new ProductListDto
            {
                Id = p.Id,
                Name = p.Name,
                CategoryName = p.Category.Name,
                Price = p.Price,
                Stock = p.Stock
            }) //select p.Id, p.Name, c.Name, p.Price, p.Stock from Products as p


            .ToListAsync();

        return Ok(products);
    }


    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateDto dto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var product = new Product()
        {
            Name = dto.Name,
            CategoryId = dto.CategoryId,
            Price = dto.Price,
            Stock = dto.Stock,
            CratedDate = DateTime.Now,
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();


        return Ok(product);
    }

    [HttpPut]
    public async Task<IActionResult> Update(ProductUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var product = new Product()
        {
            Id = dto.Id,
            Name = dto.Name,
            CategoryId = dto.CategoryId,
            Price = dto.Price,
            Stock = dto.Stock,
            UpdateDate = DateTime.Now
        };

        _context.Products.Update(product);
        await _context.SaveChangesAsync();


        return Ok(product);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var productToDelete = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (productToDelete is null)
            return NotFound("productToDelete is null");

        _context.Products.Remove(productToDelete);
        await _context.SaveChangesAsync();
        return Ok(productToDelete);
    }

}
