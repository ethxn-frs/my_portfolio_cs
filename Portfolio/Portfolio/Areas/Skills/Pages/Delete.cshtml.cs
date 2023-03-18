using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Areas.Skills.Pages
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
      public Skill Skill { get; set; }
      public string ErrorMessage { get; set; }

      public async Task<IActionResult> OnGetAsync(int? id, bool? hasErrorMessage = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Skill = await _context.Skills
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Skill == null)
            {
                return NotFound();
            }

            if (hasErrorMessage.GetValueOrDefault())
            {
                ErrorMessage = $"Une erreur est survenue lors de la tentative de suppression de {Skill.Name} ({Skill.Id})";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillToDelete = await _context.Skills
                .Include(s => s.Image)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (skillToDelete == null)
            {
                return NotFound();
            }

            try
            {
                _imageService.SkillDeleteUploadedFile(skillToDelete.Image);
                _context.Skills.Remove(skillToDelete);
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
