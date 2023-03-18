using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IList<Certification> Certifications{ get; set; } = default!;
        public IList<Project> Projects{ get; set; } = default!;
        public IList<School> Schools{ get; set; } = default!;
        public IList<Skill> Skills { get; set; } = default!;

        public IndexModel( ApplicationDbContext context, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGet()
        {
            Skills = await _context.Skills.Include(s => s.Image).ToListAsync();
            Projects = await _context.Projects.Include(p => p.Image).ToListAsync();
            Schools = await _context.Schools.Include(s => s.Image).ToListAsync();
            Certifications = await _context.Certifications.ToListAsync();
        }
    }
}