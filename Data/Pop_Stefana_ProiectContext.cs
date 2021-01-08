using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pop_Stefana_Proiect.Models;

namespace Pop_Stefana_Proiect.Data
{
    public class Pop_Stefana_ProiectContext : DbContext
    {
        public Pop_Stefana_ProiectContext (DbContextOptions<Pop_Stefana_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Pop_Stefana_Proiect.Models.Angajat> Angajat { get; set; }

        public DbSet<Pop_Stefana_Proiect.Models.Departament> Departament { get; set; }

        public DbSet<Pop_Stefana_Proiect.Models.LimbaStraina> LimbaStraina { get; set; }

        public DbSet<Pop_Stefana_Proiect.Models.Job> Job { get; set; }
    }
}
