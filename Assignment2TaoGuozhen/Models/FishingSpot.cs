using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment2TaoGuozhen.Data.Base;
using Assignment2TaoGuozhen.Data.Enums;

namespace Assignment2TaoGuozhen.Models
{
    public class FishingSpot : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime CloseDate { get; set; }

        public SpotCategory SpotCategory { get; set; }

        //Relationships
        public List<Foodcourt_FishingSpot>? Foodcourts_FishingSpots { get; set; }

        //Park
        public int ParkId { get; set; }
        [ForeignKey("ParkId")]
        public Park? Park { get; set; }
        
        //ManageCompany
        public int ManageCompanyId { get; set; }
        [ForeignKey("ManageCompanyId")]
        public ManageCompany? ManageCompany { get; set; }

    }
}
