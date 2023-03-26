using Microsoft.EntityFrameworkCore;
using Assignment2TaoGuozhen.Data.Base;
using Assignment2TaoGuozhen.Data.ViewModels;
using Assignment2TaoGuozhen.Models;

namespace Assignment2TaoGuozhen.Data.Services
{
    public class FishingSpotsService : EntityBaseRepository<FishingSpot>, IFishingSpotsService
    {
        private readonly ApplicationDbContext _context;
        public FishingSpotsService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewFishingSpotAsync(NewFishingSpotVm data)
        {
            var newFishingSpot = new FishingSpot()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageUrl,
                ParkId = data.ParkId,
                OpenDate = data.OpenDate,
                CloseDate = data.CloseDate,
                SpotCategory = data.SpotCategory,
                ManageCompanyId = data.ManageCompanyId
            };
            await _context.FishingSpots.AddAsync(newFishingSpot);
            await _context.SaveChangesAsync();

            //Add FishingSpot Foodcourts
            foreach (var foodcourtId in data.FoodcourtIds)
            {
                var newFoodcourtFishingSpot = new Foodcourt_FishingSpot()
                {
                    FishingSpotId = newFishingSpot.Id,
                    FoodcourtId = foodcourtId
                };
                await _context.FoodcourtsFishingSpots.AddAsync(newFoodcourtFishingSpot);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<FishingSpot> GetFishingSpotByIdAsync(int id)
        {
            var fishingSpotDetails = await _context.FishingSpots
                .Include(c => c.Park)
                .Include(p => p.ManageCompany)
                .Include(am => am.Foodcourts_FishingSpots).ThenInclude(a => a.Foodcourt)
                .FirstOrDefaultAsync(n => n.Id == id);

            return fishingSpotDetails;
        }

        public async Task<NewFishingSpotDropdownsVm> GetNewFishingSpotDropdownsValues()
        {
            var response = new NewFishingSpotDropdownsVm()
            {
                Foodcourts = await _context.Foodcourts.OrderBy(n => n.Name).ToListAsync(),
                Parks = await _context.Parks.OrderBy(n => n.Name).ToListAsync(),
                ManageCompanies = await _context.ManageCompanies.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public async Task UpdateFishingSpotAsync(NewFishingSpotVm data)
        {
            var dbFishingSpot = await _context.FishingSpots.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbFishingSpot != null)
            {
                dbFishingSpot.Name = data.Name;
                dbFishingSpot.Description = data.Description;
                dbFishingSpot.Price = data.Price;
                dbFishingSpot.ImageUrl = data.ImageUrl;
                dbFishingSpot.ParkId = data.ParkId;
                dbFishingSpot.OpenDate = data.OpenDate;
                dbFishingSpot.CloseDate = data.CloseDate;
                dbFishingSpot.SpotCategory = data.SpotCategory;
                dbFishingSpot.ManageCompanyId = data.ManageCompanyId;
                await _context.SaveChangesAsync();
            }

            //Remove existing foodcourts
            var existingFoodcourtsDb = _context.FoodcourtsFishingSpots.Where(n => n.FishingSpotId == data.Id).ToList();
            _context.FoodcourtsFishingSpots.RemoveRange(existingFoodcourtsDb);
            await _context.SaveChangesAsync();

            //Add FishingSpot Foodcourts
            foreach (var foodcourtId in data.FoodcourtIds)
            {
                var newFoodcourtFishingSpot = new Foodcourt_FishingSpot()
                {
                    FishingSpotId = data.Id,
                    FoodcourtId = foodcourtId
                };
                await _context.FoodcourtsFishingSpots.AddAsync(newFoodcourtFishingSpot);
            }
            await _context.SaveChangesAsync();
        }
    }
}
