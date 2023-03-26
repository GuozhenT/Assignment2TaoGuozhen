using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Assignment2TaoGuozhen.Data.Services;
using Assignment2TaoGuozhen.Data.Static;
using Assignment2TaoGuozhen.Models;

namespace Assignment2TaoGuozhen.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PromotionsController : Controller
    {
        private readonly IPromotionsService _service;

        public PromotionsController(IPromotionsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allPromotions = await _service.GetAllAsync();
            return View(allPromotions);
        }


        //Get: Parks/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Rate")]Promotion promotion)
        {
            if (!ModelState.IsValid) return View(promotion);
            await _service.AddAsync(promotion);
            return RedirectToAction(nameof(Index));
        }

        //Get: Parks/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var promotionDetails = await _service.GetByIdAsync(id);
            if (promotionDetails == null) return View("NotFound");
            return View(promotionDetails);
        }

        //Get: Promotions/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var promotionDetails = await _service.GetByIdAsync(id);
            if (promotionDetails == null) return View("NotFound");
            return View(promotionDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Rate")] Promotion promotion)
        {
            if (!ModelState.IsValid) return View(promotion);
            await _service.UpdateAsync(id, promotion);
            return RedirectToAction(nameof(Index));
        }

        //Get: Parks/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var promotionDetails = await _service.GetByIdAsync(id);
            if (promotionDetails == null) return View("NotFound");
            return View(promotionDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var promotionDetails = await _service.GetByIdAsync(id);
            if (promotionDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
