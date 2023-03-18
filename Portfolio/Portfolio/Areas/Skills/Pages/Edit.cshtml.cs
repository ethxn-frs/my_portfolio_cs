using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Data;
using Portfolio.Services;
using NuGet.Protocol.Plugins;

namespace Portfolio.Areas.Skills.Pages
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
        public Skill Skill { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            Skill = await _context.Skills
                .Include(s => s.Image)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (Skill == null)
                return NotFound();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var skillToUpdate = await _context.Skills
                .Include(s => s.Image)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (skillToUpdate == null)
                return NotFound();

            var uploadedImage = Skill.Image;

            if (null != uploadedImage)
            {
                uploadedImage = await _imageService.SkillUploadAsync(uploadedImage);

                if (skillToUpdate.Image != null)
                {
                    _imageService.SkillDeleteUploadedFile(skillToUpdate.Image);
                    skillToUpdate.Image.Name = uploadedImage.Name;
                    skillToUpdate.Image.Path = uploadedImage.Path;
                }
                else
                    skillToUpdate.Image = uploadedImage;
            }

            if (await TryUpdateModelAsync(skillToUpdate, "skill", s => s.Name, s => s.Description, s => s.Date))
            {
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool SkillExists(int id)
        {
          return (_context.Skills?.Any(s => s.Id == id)).GetValueOrDefault();
        }
    }
}
