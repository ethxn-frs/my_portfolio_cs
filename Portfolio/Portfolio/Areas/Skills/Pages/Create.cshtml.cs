using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Areas.Skills.Pages
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
        public Skill Skill { get; set; } = new();
        
        public async Task<IActionResult> OnPostAsync()
        {
            var emptySkill = new Skill();

            if (null != Skill.Image)
                emptySkill.Image = await _imageService.SkillUploadAsync(Skill.Image);

            if (await TryUpdateModelAsync(emptySkill, "skill", s => s.Name, s => s.Description, s => s.Date))
            {
                _context.Skills.Add(emptySkill);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
