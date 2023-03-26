using Assignment2TaoGuozhen.Data;
using Assignment2TaoGuozhen.Data.Base;
using Assignment2TaoGuozhen.Models;

namespace Assignment2TaoGuozhen.Data.Services
{
    public class FoodcourtsService : EntityBaseRepository<Foodcourt>, IFoodcourtsService
    {
        public FoodcourtsService(ApplicationDbContext context) : base(context) { }
    }
}
