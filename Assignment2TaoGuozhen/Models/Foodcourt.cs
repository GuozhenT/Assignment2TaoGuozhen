using System.ComponentModel.DataAnnotations;
using Assignment2TaoGuozhen.Data.Base;
using Assignment2TaoGuozhen.Data.Enums;

namespace Assignment2TaoGuozhen.Models
{
    public class Foodcourt : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public FoodcourtCategory FoodcourtCategory { get; set; }

        //Relationships
        public List<Foodcourt_FishingSpot>? Foodcourts_FishingSpots { get; set; }

    }
}
