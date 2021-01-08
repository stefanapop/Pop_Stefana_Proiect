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
    public class IndexModel : PageModel
    {
        private readonly Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext _context;

        public IndexModel(Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext context)
        {
            _context = context;
        }

        public IList<LimbaStraina> LimbaStraina { get;set; }

        public async Task OnGetAsync()
        {
            LimbaStraina = await _context.LimbaStraina.ToListAsync();
        }
    }
}
