using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Models;
using Portfolio.Data;
using Portfolio.Services;

namespace Portfolio.Areas.Schools.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ImageService _imageService;

        public CreateModel(ApplicationDbContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public School School { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            var emptySchool = new School();

            if (null != School.Image)
                emptySchool.Image = await _imageService.SchoolUploadAsync(School.Image);

            if (await TryUpdateModelAsync(emptySchool, "school", s => s.Name, s => s.Description, s => s.StartDate, s => s.EndDate))
            {
                _context.Schools.Add(emptySchool);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
