using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Data;

namespace Portfolio.Areas.Certifications.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Portfolio.Data.ApplicationDbContext _context;

        public IndexModel(Portfolio.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Certification> Certification { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Certifications != null)
            {
                Certification = await _context.Certifications.ToListAsync();
            }
        }
    }
}
