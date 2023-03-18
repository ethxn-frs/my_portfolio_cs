using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Data;

namespace Portfolio.Areas.Skills.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Skill> Skill { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Skill = await _context.Skills.Include(s => s.Image).ToListAsync();
        }
    }
}
