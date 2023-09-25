using eTickets.Data;
using eTickets.Data.Base;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private ICinemaServis _service;

        public CinemasController(ICinemaServis service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,CinemaLogo,Description")] Cinema cinema)
        {
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var allCinemas = await _service.GetByIdAsync(id);
            if (allCinemas == null) return View("NotFound");
            return View(allCinemas);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var allCinemas = await _service.GetByIdAsync(id);
            if (allCinemas == null) return View("NotFound");
            return View(allCinemas);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CinemaLogo,Description")] Cinema cinema)
        {
            if (id == cinema.Id)
            {
                await _service.UpdateAsync(id, cinema);
                return RedirectToAction(nameof(Index));
            }

            return View(cinema);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var allCinemas = await _service.GetByIdAsync(id);
            if (allCinemas == null) return View("NotFound");
            return View(allCinemas);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allCinemas = await _service.GetByIdAsync(id);
            if (allCinemas == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
