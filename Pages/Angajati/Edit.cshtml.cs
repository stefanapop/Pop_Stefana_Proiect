using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pop_Stefana_Proiect.Data;
using Pop_Stefana_Proiect.Models;

namespace Pop_Stefana_Proiect.Pages.Angajati
{
    public class EditModel : LimbaStrainaPageModel
    {
        private readonly Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext _context;

        public EditModel(Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
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
                .Include(b => b.LimbiStraineVorbite).ThenInclude(b => b.LimbaStraina)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Angajat == null)
            {
                return NotFound();
            }
            PopuleazaAtribuireLimbaStraina(_context, Angajat);
            ViewData["DepartamentID"] = new SelectList(_context.Set<Departament>(), "ID",
"NumeDepartament");
            ViewData["JobID"] = new SelectList(_context.Set<Job>(), "ID",
"TipJob");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
limbiSelectate)
        {
            if (id == null)
            {
                return NotFound();
            }
            var adaugareLb = await _context.Angajat
            .Include(i => i.Departament)
            .Include(i => i.Job)
            .Include(i => i.LimbiStraineVorbite)
            .ThenInclude(i => i.LimbaStraina)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (adaugareLb == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Angajat>(
            adaugareLb,
            "Angajat",
            i => i.NumePrenume, i => i.DataAngajarii, i => i.Email, i => i.NrTelefon,
            i => i.Salariu, i => i.DepartamentID, i => i.JobID))
            {
                UpdateLimbiStraine(_context, limbiSelectate, adaugareLb);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateLimbiStraine(_context, limbiSelectate, adaugareLb);
            PopuleazaAtribuireLimbaStraina(_context, adaugareLb);
            return Page();
        }
    }
}

