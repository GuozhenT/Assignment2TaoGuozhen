using Assignment2TaoGuozhen.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Assignment2TaoGuozhen.Models
{
    public class NewFishingSpotVm
    {
        public int Id { get; set; }

        [Display(Name = "FishingSpot name")]
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Display(Name = "FishingSpot description")]
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "FishingSpot poster URL")]
        [Required(ErrorMessage = "FishingSpot poster URL is required")]
        public string? ImageUrl { get; set; }

        [Display(Name = "FishingSpot open date")]
        [Required(ErrorMessage = "Open date is required")]
        public DateTime OpenDate { get; set; }

        [Display(Name = "FishingSpot close date")]
        [Required(ErrorMessage = "Close date is required")]
        public DateTime CloseDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "FishingSpot category is required")]
        public SpotCategory SpotCategory { get; set; }

        //Relationships
        [Display(Name = "Select Foodcourt(s)")]
        [Required(ErrorMessage = "Foodcourt(s) is required")]
        public List<int>? FoodcourtIds { get; set; }

        [Display(Name = "Select a park")]
        [Required(ErrorMessage = "Park is required")]
        public int ParkId { get; set; }

        [Display(Name = "Select a ManageCompany")]
        [Required(ErrorMessage = "ManageCompany is required")]
        public int ManageCompanyId { get; set; }
    }
}
