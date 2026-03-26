using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        List<Product> products = new List<Product>
        {
            new Product{ Id =1, Name = "Laptop" , Category = "Electronics", Price =45000},
            new Product{ Id =2, Name = "Shirt" , Category = "Fashion", Price =5000},
            new Product{ Id =3, Name = "Mobile" , Category = "Electronics", Price =20000},
            new Product{ Id =4, Name = "watch" , Category = "Accessories", Price =2000}
        };
        public IActionResult Index()
        {
            return View( products);
        }
        public IActionResult Details( )
        {
            Product ProObj = new Product() { Id = 3, Name = "Mobile", Category = "Electronics", Price = 20000 };


            return View(ProObj);
        }
    }
}
