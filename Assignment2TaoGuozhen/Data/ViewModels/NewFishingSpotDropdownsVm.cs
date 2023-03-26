using Assignment2TaoGuozhen.Models;

namespace Assignment2TaoGuozhen.Data.ViewModels
{
    public class NewFishingSpotDropdownsVm
    {
        public NewFishingSpotDropdownsVm()
        {
            Parks = new List<Park>();
            ManageCompanies = new List<ManageCompany>();
            Foodcourts = new List<Foodcourt>();
        }

        public List<Park> Parks { get; set; }
        public List<ManageCompany> ManageCompanies { get; set; }
        public List<Foodcourt> Foodcourts { get; set; }
    }
}
