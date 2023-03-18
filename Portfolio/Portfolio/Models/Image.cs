using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        [NotMapped]
        [Display(Name = "Image")]
        public IFormFile File { get; set; }
        public virtual Project? Project { get; set; }
        public int? ProjectId { get; set; }
        public virtual School? School { get; set; }
        public int? SchoolId { get; set; }
        public virtual Skill? Skill { get; set; }
        public int? SkillId { get; set; }
    }
}
