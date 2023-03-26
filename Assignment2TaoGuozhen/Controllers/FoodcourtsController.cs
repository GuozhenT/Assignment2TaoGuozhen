using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Assignment2TaoGuozhen.Data.Services;
using Assignment2TaoGuozhen.Data.Static;
using Assignment2TaoGuozhen.Models;

namespace Assignment2TaoGuozhen.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class FoodcourtsController : Controller
    {
        private readonly IFoodcourtsService _service;

        public FoodcourtsController(IFoodcourtsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Foodcourts/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description,FoodcourtCategory")]Foodcourt foodcourt)
        {
            if (!ModelState.IsValid)
            {
                return View(foodcourt);
            }
            await _service.AddAsync(foodcourt);
            return RedirectToAction(nameof(Index));
        }

        //Get: Foodcourts/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var foodcourtDetails = await _service.GetByIdAsync(id);

            if (foodcourtDetails == null) return View("NotFound");
            return View(foodcourtDetails);
        }

        //Get: Foodcourts/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var foodcourtDetails = await _service.GetByIdAsync(id);
            if (foodcourtDetails == null) return View("NotFound");
            return View(foodcourtDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,FoodcourtCategory")] Foodcourt foodcourt)
        {
            if (!ModelState.IsValid)
            {
                return View(foodcourt);
            }
            await _service.UpdateAsync(id, foodcourt);
            return RedirectToAction(nameof(Index));
        }

        //Get: Foodcourts/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var foodcourtDetails = await _service.GetByIdAsync(id);
            if (foodcourtDetails == null) return View("NotFound");
            return View(foodcourtDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodcourtDetails = await _service.GetByIdAsync(id);
            if (foodcourtDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
