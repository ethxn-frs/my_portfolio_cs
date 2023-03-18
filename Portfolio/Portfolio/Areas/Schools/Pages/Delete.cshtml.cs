using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Data;
using Portfolio.Services;

namespace Portfolio.Areas.Schools.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Portfolio.Data.ApplicationDbContext _context;
        private ImageService _imageService;

        public DeleteModel(ApplicationDbContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        [BindProperty]
      public School School { get; set; }
      public string ErrorMessage { get; set; }

      public async Task<IActionResult> OnGetAsync(int? id, bool? hasErrorMessage = false)
        {
            if (id == null || _context.Schools == null)
            {
                return NotFound();
            }

            School = await _context.Schools
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (School == null)
            {
                return NotFound();
            }
            if (hasErrorMessage.GetValueOrDefault())
            {
                ErrorMessage = $"Une erreur est survenue lors de la tentative de suppression de {School.Name} ({School.Id})";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolToDelete = await _context.Schools
                .Include(s => s.Image)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (schoolToDelete == null)
            {
                return NotFound();
            }

            try
            {
                _imageService.SchoolDeleteUploadedFile(schoolToDelete.Image);
                _context.Schools.Remove(schoolToDelete);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                return RedirectToAction("./Delete", new { id, hasErrorMessage = true });
            }
        }
    }
}
