using System.ComponentModel.DataAnnotations;

namespace Bearstrength.Models
{
    public class Category
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }
    }
}