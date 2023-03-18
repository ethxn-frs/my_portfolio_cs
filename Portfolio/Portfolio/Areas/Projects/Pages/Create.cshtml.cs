using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Models;
using Portfolio.Data;
using Portfolio.Services;

namespace Portfolio.Areas.Projects.Pages
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
        public Project Project { get; set; } = new();
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyProject = new Project();

            if (null != Project.Image)
                emptyProject.Image = await _imageService.ProjectUploadAsync(Project.Image);

            if (await TryUpdateModelAsync(emptyProject, "project", p => p.Name, p => p.Description, p => p.ShortDescription, p => p.Context, p => p.TimeSpent, p => p.State, p => p.Technologies, p => p.Link))
            {
                _context.Projects.Add(emptyProject);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
