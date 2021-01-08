using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pop_Stefana_Proiect.Data;
using Pop_Stefana_Proiect.Models;

namespace Pop_Stefana_Proiect.Pages.Angajati
{
    public class DetailsModel : PageModel
    {
        private readonly Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext _context;

        public DetailsModel(Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext context)
        {
            _context = context;
        }

        public Angajat Angajat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Angajat = await _context.Angajat
                .Include(b => b.Departament)
                .Include(b => b.Job)
                .Include(b => b.LimbiStraineVorbite)
                .ThenInclude(b => b.LimbaStraina)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Angajat == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
