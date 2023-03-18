using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Data;
using Portfolio.Services;

namespace Portfolio.Areas.Projects.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ImageService _imageService;

        public EditModel(ApplicationDbContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        [BindProperty]
        public Project Project { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            Project = await _context.Projects
                .Include(s => s.Image)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (Project == null)
                return NotFound();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var projectToUpdate = await _context.Projects
                .Include(p=> p.Image)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (projectToUpdate == null)
                return NotFound();

            var uploadedImage = Project.Image;

            if (null != uploadedImage)
            {
                uploadedImage = await _imageService.ProjectUploadAsync(uploadedImage);

                if (projectToUpdate.Image != null)
                {
                    _imageService.ProjectDeleteUploadedFile(projectToUpdate.Image);
                    projectToUpdate.Image.Name = uploadedImage.Name;
                    projectToUpdate.Image.Path = uploadedImage.Path;
                }
                else
                    projectToUpdate.Image = uploadedImage;
            }


            if (await TryUpdateModelAsync(projectToUpdate, "project", p => p.Name, p => p.Description, p => p.ShortDescription, p => p.Context, p => p.TimeSpent, p => p.State, p => p.Technologies, p => p.Link))
            {
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool ProjectExists(int id)
        {
          return (_context.Projects?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
