using Assignment2TaoGuozhen.Data.Base;
using Assignment2TaoGuozhen.Data.ViewModels;
using Assignment2TaoGuozhen.Models;

namespace Assignment2TaoGuozhen.Data.Services
{
    public interface IFishingSpotsService:IEntityBaseRepository<FishingSpot>
    {
        Task<FishingSpot> GetFishingSpotByIdAsync(int id);
        Task<NewFishingSpotDropdownsVm> GetNewFishingSpotDropdownsValues();
        Task AddNewFishingSpotAsync(NewFishingSpotVm data);
        Task UpdateFishingSpotAsync(NewFishingSpotVm data);
    }
}
