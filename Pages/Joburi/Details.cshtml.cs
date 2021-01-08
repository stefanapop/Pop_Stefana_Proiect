using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pop_Stefana_Proiect.Data;
using Pop_Stefana_Proiect.Models;

namespace Pop_Stefana_Proiect.Pages.Joburi
{
    public class DetailsModel : PageModel
    {
        private readonly Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext _context;

        public DetailsModel(Pop_Stefana_Proiect.Data.Pop_Stefana_ProiectContext context)
        {
            _context = context;
        }

        public Job Job { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job = await _context.Job.FirstOrDefaultAsync(m => m.ID == id);

            if (Job == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
