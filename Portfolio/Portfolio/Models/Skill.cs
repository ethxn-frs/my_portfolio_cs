using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Date { get; set; }
        public virtual Image? Image { get; set; }

    }
}
