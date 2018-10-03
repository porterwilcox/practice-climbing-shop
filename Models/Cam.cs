using System.ComponentModel.DataAnnotations;

namespace practiceClimbingShop.Models
{
    public class Cam
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public float Size { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Cam() { }
    }
}