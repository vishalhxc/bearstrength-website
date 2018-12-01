using System.ComponentModel.DataAnnotations;

namespace Bearstrength.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Category Category { get; set; }

        [Required]
        public byte CategoryId { get; set; }
    }
}