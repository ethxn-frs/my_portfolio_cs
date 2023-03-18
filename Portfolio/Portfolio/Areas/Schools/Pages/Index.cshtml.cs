using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Data;

namespace Portfolio.Areas.Schools.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<School> Schools { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Schools != null)
            {
                Schools = await _context.Schools.Include(s => s.Image).ToListAsync();
            }
        }
    }
}
