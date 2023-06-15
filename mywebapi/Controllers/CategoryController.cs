using Microsoft.AspNetCore.Mvc;
using mywebapi.Data;
using mywebapi.Models;

namespace mywebapi.Controllers;

[ApiController]
[Route("[controller]")]

public class CategoryController : ControllerBase
{
    public readonly MyDbContext _context;
    public CategoryController(MyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(_context.Categories.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetCategoryById(string id)
    {
        try
        {
            var cater = _context.Categories.FirstOrDefault(c => c.CategoryId == Int32.Parse(id));
            // LINQ
            if(cater == null)
            {
                return NotFound();
            }
            return Ok(cater);
        }
        catch (Exception e)
        {
            
            return BadRequest();
        }
    }

    [HttpPost]
    public IActionResult CreateCategory(CategoryModel category)
    {
        try
        {
        Category cat = new Category
        {
            Name = category.Name
        };
            _context.Add(cat);
            _context.SaveChanges();
        return Ok(new 
        {
            Success = true,
            Data = cat
        });
        }
        catch (Exception e)
        {
            
            Console.WriteLine(e);
            return BadRequest();
        }
        
        
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(string id, CategoryModel updatedCategory)
    {
         try
        {
            var cat = _context.Categories.FirstOrDefault(c => c.CategoryId == Int32.Parse(id));
            // LINQ
            if(cat == null)
            {
                return NotFound();
            }
            // Update
            if(id != cat.CategoryId.ToString())
            {
                return BadRequest();
            }
            cat.Name = updatedCategory.Name;
            _context.SaveChanges();
            return Ok();
        }
        catch(Exception e)
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveProduct(string id)
    {
        try
        {
            var cat = _context.Categories.SingleOrDefault(c => 
            c.CategoryId == Int32.Parse(id));
            if (cat == null)
                return NotFound();
            _context.Remove(cat);
            _context.SaveChanges();
            return Ok();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
        
    }
}