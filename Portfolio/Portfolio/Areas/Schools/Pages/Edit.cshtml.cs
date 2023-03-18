using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Areas.Schools.Pages
{
    public class EditModel : PageModel
    {
        private readonly Portfolio.Data.ApplicationDbContext _context;
        private readonly ImageService _imageService;

        public EditModel(Portfolio.Data.ApplicationDbContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        [BindProperty] 
        public School School { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Schools == null)
            {
                return NotFound();
            }

            School = await _context.Schools
                .Include(s => s.Image)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (School == null)
                return NotFound();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var schoolToUpdate = await _context.Schools
                .Include(s => s.Image)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (schoolToUpdate == null)
                return NotFound();

            var uploadedImage = School.Image;

            if (null != uploadedImage)
            {
                uploadedImage = await _imageService.SchoolUploadAsync(uploadedImage);

                if (schoolToUpdate.Image != null)
                {
                    _imageService.SchoolDeleteUploadedFile(schoolToUpdate.Image);
                    schoolToUpdate.Image.Name = uploadedImage.Name;
                    schoolToUpdate.Image.Path = uploadedImage.Path;
                }
                else
                    schoolToUpdate.Image = uploadedImage;
            }

            if (await TryUpdateModelAsync(schoolToUpdate, "school", s => s.Name, s => s.Description, s => s.StartDate, s => s.EndDate))
            {
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool SchoolExists(int id)
        {
          return (_context.Schools?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
