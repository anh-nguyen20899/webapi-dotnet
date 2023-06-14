using Microsoft.AspNetCore.Mvc;
using mywebapi.Models;

namespace mywebapi.Controllers;

[ApiController]
[Route("[controller]")]

public class ProductController : ControllerBase
{
    public static List<Product> _products = new List<Product>();

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(_products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(string id)
    {
        try
        {
            var product = _products.FirstOrDefault(p => p.Id == Guid.Parse(id));
            // LINQ
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        catch (Exception e)
        {
            
            return BadRequest();
        }
    }

    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        Product p = new Product
        {
            Id = Guid.NewGuid(),
            Name = product.Name,
            Price = product.Price

        };
        _products.Add(p);
        return Ok(new 
        {
            Success = true,
            Data = p
        });
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(string id, Product updatedProduct)
    {
         try
        {
            var product = _products.FirstOrDefault(p => p.Id == Guid.Parse(id));
            // LINQ
            if(product == null)
            {
                return NotFound();
            }
            // Update
            if(id != updatedProduct.Id.ToString())
            {
                return BadRequest();
            }
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
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
            var product = _products.SingleOrDefault(p => 
            p.Id == Guid.Parse(id));
            if (product == null)
                return NotFound();
            _products.Remove(product);
            return Ok();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
        
    }
}