using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class School
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string StartDate { get; set; }
        public string? EndDate { get; set;}
        public virtual Image Image { get; set; }

    }
}
