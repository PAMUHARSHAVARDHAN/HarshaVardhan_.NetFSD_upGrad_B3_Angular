using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("Calculator")]
    public class CalculatorController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("calculate")]
        public IActionResult Calculate( double num1, double num2, string operation)
        {
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
            }
            ViewData["Result"] = result;
            ViewData["Num1"] = num1;
            ViewData["Num2"] = num2;
            ViewData["Operation"] = operation;
            return View("Index");
        }
    }
}
