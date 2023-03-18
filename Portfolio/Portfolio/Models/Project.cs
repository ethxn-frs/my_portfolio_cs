using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Context { get; set; }
        [Required]
        public string TimeSpent { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Technologies { get; set; }
        public string? Link { get; set; }
        public virtual Image Image { get; set; }

    }
}
