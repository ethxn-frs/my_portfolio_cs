using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Data;

namespace Portfolio.Areas.Schools.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Portfolio.Data.ApplicationDbContext _context;

        public DetailsModel(Portfolio.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public School School { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Schools == null)
            {
                return NotFound();
            }

            var school = await _context.Schools.FirstOrDefaultAsync(m => m.Id == id);
            if (school == null)
            {
                return NotFound();
            }
            else 
            {
                School = school;
            }
            return Page();
        }
    }
}
