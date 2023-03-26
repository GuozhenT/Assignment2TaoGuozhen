using System.ComponentModel.DataAnnotations;
using Assignment2TaoGuozhen.Data.Base;

namespace Assignment2TaoGuozhen.Models
{
    public class Promotion : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public double? Rate { get; set; }

        //Relationships

        public List<FishingSpot>? FishingSpots { get; set;}

    }
}
