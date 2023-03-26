using System.ComponentModel.DataAnnotations;

namespace Assignment2TaoGuozhen.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public FishingSpot? FishingSpot { get; set; }
        public int Amount { get; set; }


        public string? ShoppingCartId { get; set; }
    }
}
