using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Data;
using Portfolio.Services;

namespace Portfolio.Areas.Projects.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private ImageService _imageService;

        public DeleteModel(ApplicationDbContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        [BindProperty]
      public Project Project { get; set; } = default!;
      public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? hasErrorMessage = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Projects
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Project == null)
            {
                return NotFound();
            }

            if (hasErrorMessage.GetValueOrDefault())
            {
                ErrorMessage = $"Une erreur est survenue lors de la tentative de suppression de {Project.Name} ({Project.Id})";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectToDelete = await _context.Projects
                .Include(s => s.Image)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (projectToDelete == null)
            {
                return NotFound();
            }

            try
            {
                _imageService.ProjectDeleteUploadedFile(projectToDelete.Image);
                _context.Projects.Remove(projectToDelete);
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
