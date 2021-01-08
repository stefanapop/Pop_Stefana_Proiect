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
    public class IndexModel : PageModel
    {
        private readonly Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext _context;

        public IndexModel(Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext context)
        {
            _context = context;
        }

        public IList<Angajat> Angajat { get;set; }
        public AngajatData AngajatD { get; set; }
        public int AngajatID { get; set; }
        public int LimbaStrainaID { get; set; }


        public async Task OnGetAsync(int? id, int? lbstID)
        {
            AngajatD = new AngajatData();

            AngajatD.Angajati = await _context.Angajat
            .Include(b => b.Departament)
            .Include(b => b.Job)
            .Include(b => b.LimbiStraineVorbite)
            .ThenInclude(b => b.LimbaStraina)
            .AsNoTracking()
            .OrderBy(b => b.NumePrenume)
            .ToListAsync();
            if (id != null)
            {
                AngajatID = id.Value;
                Angajat angajat = AngajatD.Angajati
                .Where(i => i.ID == id.Value).Single();
                AngajatD.LimbiStraine = angajat.LimbiStraineVorbite.Select(s => s.LimbaStraina);
            }
        }
    }
}
