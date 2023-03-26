using Assignment2TaoGuozhen.Data.Base;
using Assignment2TaoGuozhen.Models;

namespace Assignment2TaoGuozhen.Data.Services
{
    public class PromotionsService:EntityBaseRepository<Promotion>, IPromotionsService
    {
        public PromotionsService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
