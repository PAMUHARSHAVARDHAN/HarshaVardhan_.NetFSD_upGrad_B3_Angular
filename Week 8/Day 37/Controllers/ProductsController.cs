using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
        {
            new Product{ Id = 1, Name = "motrola", Price =30000},
            new Product{ Id = 2, Name = "samsung", Price =25000},
            new Product{ Id = 3, Name = "iphone", Price =50000},
        };
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(products);
        }
        [HttpPost]
        public IActionResult AddProducts(Product product)
        {
            products.Add(product);
            return Ok("New Products are succefully added to the server");
        }
    }
}
