using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("StRegistration")]
    public class StRegistrationController : Controller
    {
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("submit")]
        public IActionResult Submit( string name, int age, string course)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;
            return RedirectToAction("Display",new
            {
                name = name,
                age = age,
                course = course
            });
        }
        [HttpGet("display")]
        public IActionResult Display( string name, int age , string course)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;
            return View();
        }
    }
}
