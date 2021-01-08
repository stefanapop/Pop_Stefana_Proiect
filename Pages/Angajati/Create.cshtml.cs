using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pop_Stefana_Proiect.Data;
using Pop_Stefana_Proiect.Models;

namespace Pop_Stefana_Proiect.Pages.Angajati
{
    public class CreateModel : LimbaStrainaPageModel
    {
        private readonly Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext _context;

        public CreateModel(Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DepartamentID"] = new SelectList(_context.Set<Departament>(), "ID",
"NumeDepartament");
            ViewData["JobID"] = new SelectList(_context.Set<Job>(), "ID",
"TipJob");
            var angajat = new Angajat();
            angajat.LimbiStraineVorbite = new List<LimbaStrainaVorbita>();
            PopuleazaAtribuireLimbaStraina(_context, angajat);
            return Page();
        }

        [BindProperty]
        public Angajat Angajat { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] limbiSelectate)
        {
            var nouAngajat = new Angajat();
            if (limbiSelectate != null)
            {
                nouAngajat.LimbiStraineVorbite = new List<LimbaStrainaVorbita>();
                foreach (var lb in limbiSelectate)
                {
                    var lbAdauga = new LimbaStrainaVorbita
                    {
                        LimbaStrainaID = int.Parse(lb)
                    };
                    nouAngajat.LimbiStraineVorbite.Add(lbAdauga);
                }
            }
            if (await TryUpdateModelAsync<Angajat>(
            nouAngajat,
            "Angajat",
             i => i.NumePrenume, i => i.DataAngajarii, i => i.Email, i => i.NrTelefon,
            i => i.Salariu, i => i.DepartamentID, i => i.JobID))
            {
                _context.Angajat.Add(nouAngajat);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopuleazaAtribuireLimbaStraina(_context, nouAngajat);
            return Page();
        }
    }
}
