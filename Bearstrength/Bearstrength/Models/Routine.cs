using System;
using System.ComponentModel.DataAnnotations;

namespace Bearstrength.Models
{
    public class Routine
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(1, 999)]
        public int Sequence { get; set; }

        [Required]
        [Range(1, 999)]
        public int Sets { get; set; }

        [Required]
        [Range(1, 9999)]
        public int Repetitions { get; set; }

        [Required]
        [Range(1, 9999)]
        public int Weight { get; set; }

        [Required]
        public TimeSpan Rest { get; set; }

        [Required]
        public BearstrengthUser User { get; set; }

        [Required]
        public Activity Activity { get; set; }
    }
}
