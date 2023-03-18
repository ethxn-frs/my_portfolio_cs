using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Models;
using Portfolio.Data;

namespace Portfolio.Areas.Certifications.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Portfolio.Data.ApplicationDbContext _context;

        public CreateModel(Portfolio.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Certification Certification { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Certifications == null || Certification == null)
            {
                return Page();
            }

            _context.Certifications.Add(Certification);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
