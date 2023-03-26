using System.ComponentModel.DataAnnotations;
using Assignment2TaoGuozhen.Data.Base;

namespace Assignment2TaoGuozhen.Models
{
    public class ManageCompany : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public string? Name { get; set; }

        public string? ContactNumber { get; set; }

        //RelationShips
        public List<FishingSpot>? FishingSpots { get; set;}
    }
}
