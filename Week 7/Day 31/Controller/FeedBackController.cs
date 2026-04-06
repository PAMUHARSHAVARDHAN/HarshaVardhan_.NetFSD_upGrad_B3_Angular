using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("FeedBack")]
    public class FeedBackController : Controller
    {

       
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("submit")]
        public IActionResult Submit(string name, string comment , int rating)
        {
            
         
           
                if (rating>= 4)
                {
                ViewData["Message"] = "Thank you  ";
                }
                else
                {
                ViewData["Message"] = "we will improve";
                }
            
            
            ViewData["Name"] = name;
           
            return View("Index");
        }
    }
}
