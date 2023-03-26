using Assignment2TaoGuozhen.Data.Base;
using Assignment2TaoGuozhen.Models;

namespace Assignment2TaoGuozhen.Data.Services
{
    public class ParksService:EntityBaseRepository<Park>, IParksService
    {
        public ParksService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
