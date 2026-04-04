using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;
        public MoviesController(IMovieService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var movies = _service.GetMovies();
            return View(movies);
        }
        public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.AddMovie(movie);
                return RedirectToAction("Index");
            }
           
           
                return View(movie);

            


        }
        [HttpGet]
        public IActionResult Edit( int id )
        {
            var movie = _service.GetMovie(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateMovie(movie);
                return RedirectToAction("Index");
            }
            return View(movie);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {


            var movie = _service.GetMovie(id);
            return View(movie);

        }
        [HttpPost]
        public IActionResult DeleteConfirm( int id)
        {
            _service.DeleteMovie(id);
            return RedirectToAction("Index");


        }

    }
}
