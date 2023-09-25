using eTickets.Data;
using eTickets.Data.Base;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _cinemasService;
        
        public MoviesController(IMoviesService cinemasService)
        {
            _cinemasService = cinemasService;
        }
        
        public async Task<IActionResult> Index()
        {
            var allMovies = await _cinemasService.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _cinemasService.GetAllAsync(n => n.Cinema);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allMovies);
        }
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _cinemasService.GetMovieByIdAsync(id);
            return View(movieDetail);
        }
        public async Task<IActionResult> Create()
        {
            var movieDropDownData = await _cinemasService.GetNewMovieDropdownsVMValues();
            ViewBag.Cinemass = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
            ViewBag.Producerss = new SelectList(movieDropDownData.Producers, "Id", "FullName");
            ViewBag.Actorss = new SelectList(movieDropDownData.Actors, "Id", "FullName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVm movie)
        {
            var movieDropDownData = await _cinemasService.GetNewMovieDropdownsVMValues();
            ViewBag.Cinemass = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
            ViewBag.Producerss = new SelectList(movieDropDownData.Producers, "Id", "FullName");
            ViewBag.Actorss = new SelectList(movieDropDownData.Actors, "Id", "FullName");
            await _cinemasService.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _cinemasService.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieVm()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                CinemaID = movieDetails.CinemaID,
                ProducerID = movieDetails.ProducerID,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };

            var movieDropDownData = await _cinemasService.GetNewMovieDropdownsVMValues();
            ViewBag.Cinemass = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
            ViewBag.Producerss = new SelectList(movieDropDownData.Producers, "Id", "FullName");
            ViewBag.Actorss = new SelectList(movieDropDownData.Actors, "Id", "FullName");

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVm movie)
        {
            if (id != movie.Id) return View("NotFound");

            var movieDropDownData = await _cinemasService.GetNewMovieDropdownsVMValues();
            ViewBag.Cinemass = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
            ViewBag.Producerss = new SelectList(movieDropDownData.Producers, "Id", "FullName");
            ViewBag.Actorss = new SelectList(movieDropDownData.Actors, "Id", "FullName");
            await _cinemasService.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}


