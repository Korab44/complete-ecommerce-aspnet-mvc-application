using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersServices _services;

        public ProducersController(IProducersServices services)
        {
            _services = services;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await _services.GetAllAsync();
            return View(allProducers);
        }
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _services.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,BIO")] Producer producer)
        {
            await _services.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _services.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName,ProfilePictureURL,BIO")] Producer producer)
        {
            if (id == producer.Id)
            {
                await _services.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }

            return View(producer);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _services.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _services.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");

            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
