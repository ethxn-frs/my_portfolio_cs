using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Data;

namespace Portfolio.Areas.Certifications.Pages
{
    public class EditModel : PageModel
    {
        private readonly Portfolio.Data.ApplicationDbContext _context;

        public EditModel(Portfolio.Data.ApplicationDbContext context)
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

            var certification =  await _context.Certifications.FirstOrDefaultAsync(m => m.Id == id);
            if (certification == null)
            {
                return NotFound();
            }
            Certification = certification;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Certification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificationExists(Certification.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CertificationExists(int id)
        {
          return (_context.Certifications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
