using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
       public  static List<Product> products = new List<Product>
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
        public IActionResult Details( int id)
        {
            Product ProObj = products.FirstOrDefault(p => p.Id == id);
            return View(ProObj);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product Obj)
        {
            if (ModelState.IsValid)
            {
                products.Add(Obj);
                return RedirectToAction("Index");
            }
            return View(Obj);
            
        }
        [HttpGet]
        public IActionResult Edit( int id)
        {
            Product ProObj = products.FirstOrDefault(p => p.Id == id);
            return View(ProObj);
        }
        [HttpPost]
        public IActionResult Edit( Product pro)
        {
            if (ModelState.IsValid)
            {
                var ExistPro = products.FirstOrDefault(x => x.Id == pro.Id);
                if (ExistPro != null)
                {
                    ExistPro.Id = pro.Id;
                    ExistPro.Name = pro.Name;
                    ExistPro.Category = pro.Category;
                    ExistPro.Price = pro.Price;
                }
                return RedirectToAction("Index");
            }
            return View(pro);
               
            
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product ProObj = products.FirstOrDefault(p => p.Id == id);
            return View(ProObj);
        }
        [HttpPost]
        public IActionResult Deleteconfirm(int id)
        {
            Product ProObj = products.FirstOrDefault(p => p.Id == id);
            products.Remove(ProObj);
            return RedirectToAction("Index");
        }


    }

}
