using Assignment2TaoGuozhen.Data.Base;
using Assignment2TaoGuozhen.Models;

namespace Assignment2TaoGuozhen.Data.Services
{
    public class ManageCompaniesService: EntityBaseRepository<ManageCompany>, IManageCompaniesService
    {
        public ManageCompaniesService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
