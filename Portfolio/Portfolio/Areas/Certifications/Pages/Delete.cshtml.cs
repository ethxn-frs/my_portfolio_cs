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
    public class DeleteModel : PageModel
    {
        private readonly Portfolio.Data.ApplicationDbContext _context;

        public DeleteModel(Portfolio.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Certification Certification { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Certifications == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications.FirstOrDefaultAsync(m => m.Id == id);

            if (certification == null)
            {
                return NotFound();
            }
            else 
            {
                Certification = certification;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Certifications == null)
            {
                return NotFound();
            }
            var certification = await _context.Certifications.FindAsync(id);

            if (certification != null)
            {
                Certification = certification;
                _context.Certifications.Remove(Certification);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
