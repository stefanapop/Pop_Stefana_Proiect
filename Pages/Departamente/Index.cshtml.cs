using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pop_Stefana_Proiect.Data;
using Pop_Stefana_Proiect.Models;

namespace Pop_Stefana_Proiect.Pages.Departamente
{
    public class IndexModel : PageModel
    {
        private readonly Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext _context;

        public IndexModel(Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext context)
        {
            _context = context;
        }

        public IList<Departament> Departament { get;set; }

        public async Task OnGetAsync()
        {
            Departament = await _context.Departament.ToListAsync();
        }
    }
}
