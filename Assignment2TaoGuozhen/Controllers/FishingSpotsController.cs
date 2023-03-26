using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment2TaoGuozhen.Data.Services;
using Assignment2TaoGuozhen.Data.Static;
using Assignment2TaoGuozhen.Models;

namespace Assignment2TaoGuozhen.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class FishingSpotsController : Controller
    {
        private readonly IFishingSpotsService _service;

        public FishingSpotsController(IFishingSpotsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allFishingSpots = await _service.GetAllAsync(n => n.Park);
            return View(allFishingSpots);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allFishingSpots = await _service.GetAllAsync(n => n.Park);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allFishingSpots.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                //var filteredResultNew = allFishingSpots.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                var filteredResultNew = allFishingSpots.Where(n => n.Name.Contains(searchString)|| n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResultNew);
            }

            return View("Index", allFishingSpots);
        }

        //GET: FishingSpots/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var fishingSpotDetail = await _service.GetFishingSpotByIdAsync(id);
            return View(fishingSpotDetail);
        }

        //GET: FishingSpots/Create
        public async Task<IActionResult> Create()
        {
            var fishingSpotDropdownsData = await _service.GetNewFishingSpotDropdownsValues();

            ViewBag.Parks = new SelectList(fishingSpotDropdownsData.Parks, "Id", "Name");
            ViewBag.ManageCompanies = new SelectList(fishingSpotDropdownsData.ManageCompanies, "Id", "Name");
            ViewBag.Foodcourts = new SelectList(fishingSpotDropdownsData.Foodcourts, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewFishingSpotVm fishingSpot)
        {
            if (!ModelState.IsValid)
            {
                var fishingSpotDropdownsData = await _service.GetNewFishingSpotDropdownsValues();

                ViewBag.Parks = new SelectList(fishingSpotDropdownsData.Parks, "Id", "Name");
                ViewBag.ManageCompanies = new SelectList(fishingSpotDropdownsData.ManageCompanies, "Id", "Name");
                ViewBag.Foodcourts = new SelectList(fishingSpotDropdownsData.Foodcourts, "Id", "Name");

                return View(fishingSpot);
            }

            await _service.AddNewFishingSpotAsync(fishingSpot);
            return RedirectToAction(nameof(Index));
        }


        //GET: FishingSpots/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var fishingSpotDetails = await _service.GetFishingSpotByIdAsync(id);
            if (fishingSpotDetails == null) return View("NotFound");

            var response = new NewFishingSpotVm()
            {
                Id = fishingSpotDetails.Id,
                Name = fishingSpotDetails.Name,
                Description = fishingSpotDetails.Description,
                Price = fishingSpotDetails.Price,
                OpenDate = fishingSpotDetails.OpenDate,
                CloseDate = fishingSpotDetails.CloseDate,
                ImageUrl = fishingSpotDetails.ImageUrl,
                SpotCategory = fishingSpotDetails.SpotCategory,
                ParkId = fishingSpotDetails.ParkId,
                ManageCompanyId = fishingSpotDetails.ManageCompanyId,
                FoodcourtIds = fishingSpotDetails.Foodcourts_FishingSpots.Select(n => n.FoodcourtId).ToList(),
            };

            var fishingSpotDropdownsData = await _service.GetNewFishingSpotDropdownsValues();
            ViewBag.Parks = new SelectList(fishingSpotDropdownsData.Parks, "Id", "Name");
            ViewBag.ManageCompanies = new SelectList(fishingSpotDropdownsData.ManageCompanies, "Id", "Name");
            ViewBag.Foodcourts = new SelectList(fishingSpotDropdownsData.Foodcourts, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewFishingSpotVm fishingSpot)
        {
            if (id != fishingSpot.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var fishingSpotDropdownsData = await _service.GetNewFishingSpotDropdownsValues();

                ViewBag.Parks = new SelectList(fishingSpotDropdownsData.Parks, "Id", "Name");
                ViewBag.ManageCompanies = new SelectList(fishingSpotDropdownsData.ManageCompanies, "Id", "Name");
                ViewBag.Foodcourts = new SelectList(fishingSpotDropdownsData.Foodcourts, "Id", "Name");

                return View(fishingSpot);
            }

            await _service.UpdateFishingSpotAsync(fishingSpot);
            return RedirectToAction(nameof(Index));
        }

    }
}