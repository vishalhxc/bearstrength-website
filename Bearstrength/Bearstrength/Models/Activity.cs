using System.ComponentModel.DataAnnotations;

namespace Bearstrength.Models
{
    /// <summary>
    /// Activity class is one instance of an activity or exercise 
    /// (e.g. bench press, squat, jog, basketball game, etc.)
    /// </summary>
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public BearstrengthUser User { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Category Category { get; set; }

        [Required]
        public byte CategoryId { get; set; }
    }
}