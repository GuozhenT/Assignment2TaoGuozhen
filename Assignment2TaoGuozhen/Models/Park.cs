using System.ComponentModel.DataAnnotations;
using Assignment2TaoGuozhen.Data.Base;

namespace Assignment2TaoGuozhen.Models
{
    public class Park : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        //Relationships

        public List<FishingSpot>? FishingSpots { get; set;}

    }
}
