using System.ComponentModel.DataAnnotations;

namespace Bearstrength.Models
{
    /// <summary>
    /// A descriptor type for Activity
    /// </summary>
    public class Category
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }
    }
}