using System.ComponentModel.DataAnnotations;

namespace practiceClimbingShop.Models
{
    public class Rope
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Rope() { }
    }
}