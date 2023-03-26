using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Assignment2TaoGuozhen.Data.Services;
using Assignment2TaoGuozhen.Data.Static;
using Assignment2TaoGuozhen.Models;

namespace Assignment2TaoGuozhen.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ParksController : Controller
    {
        private readonly IParksService _service;

        public ParksController(IParksService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allParks = await _service.GetAllAsync();
            return View(allParks);
        }


        //Get: Parks/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Address")]Park park)
        {
            if (!ModelState.IsValid) return View(park);
            await _service.AddAsync(park);
            return RedirectToAction(nameof(Index));
        }

        //Get: Parks/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var parkDetails = await _service.GetByIdAsync(id);
            if (parkDetails == null) return View("NotFound");
            return View(parkDetails);
        }

        //Get: Parks/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var parkDetails = await _service.GetByIdAsync(id);
            if (parkDetails == null) return View("NotFound");
            return View(parkDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address")] Park park)
        {
            if (!ModelState.IsValid) return View(park);
            await _service.UpdateAsync(id, park);
            return RedirectToAction(nameof(Index));
        }

        //Get: Parks/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var parkDetails = await _service.GetByIdAsync(id);
            if (parkDetails == null) return View("NotFound");
            return View(parkDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var parkDetails = await _service.GetByIdAsync(id);
            if (parkDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
