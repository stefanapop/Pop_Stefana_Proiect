using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pop_Stefana_Proiect.Data;
using Pop_Stefana_Proiect.Models;

namespace Pop_Stefana_Proiect.Pages.LimbiStraine
{
    public class DeleteModel : PageModel
    {
        private readonly Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext _context;

        public DeleteModel(Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LimbaStraina LimbaStraina { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LimbaStraina = await _context.LimbaStraina.FirstOrDefaultAsync(m => m.ID == id);

            if (LimbaStraina == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LimbaStraina = await _context.LimbaStraina.FindAsync(id);

            if (LimbaStraina != null)
            {
                _context.LimbaStraina.Remove(LimbaStraina);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
