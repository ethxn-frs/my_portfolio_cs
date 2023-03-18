using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Certification
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string State { get; set; }
    }
}
