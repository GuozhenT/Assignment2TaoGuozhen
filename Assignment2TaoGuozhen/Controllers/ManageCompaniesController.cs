using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Assignment2TaoGuozhen.Data.Services;
using Assignment2TaoGuozhen.Data.Static;
using Assignment2TaoGuozhen.Models;

namespace Assignment2TaoGuozhen.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ManageCompaniesController : Controller
    {
        private readonly IManageCompaniesService _service;

        public ManageCompaniesController(IManageCompaniesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allManageCompanies = await _service.GetAllAsync();
            return View(allManageCompanies);
        }

        //GET: manageCompanies/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var manageCompanyDetails = await _service.GetByIdAsync(id);
            if (manageCompanyDetails == null) return View("NotFound");
            return View(manageCompanyDetails);
        }

        //GET: manageCompanies/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureUrl,Name,ContactNumber")]ManageCompany manageCompany)
        {
            if (!ModelState.IsValid) return View(manageCompany);

            await _service.AddAsync(manageCompany);
            return RedirectToAction(nameof(Index));
        }

        //GET: manageCompanies/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var manageCompanyDetails = await _service.GetByIdAsync(id);
            if (manageCompanyDetails == null) return View("NotFound");
            return View(manageCompanyDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureUrl,Name,ContactNumber")] ManageCompany manageCompany)
        {
            if (!ModelState.IsValid) return View(manageCompany);

            if(id == manageCompany.Id)
            {
                await _service.UpdateAsync(id, manageCompany);
                return RedirectToAction(nameof(Index));
            }
            return View(manageCompany);
        }

        //GET: manageCompanies/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var manageCompanyDetails = await _service.GetByIdAsync(id);
            if (manageCompanyDetails == null) return View("NotFound");
            return View(manageCompanyDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manageCompanyDetails = await _service.GetByIdAsync(id);
            if (manageCompanyDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
