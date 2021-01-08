using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pop_Stefana_Proiect.Models
{
    public class Job
    {
        public int ID { get; set; }
        [Display(Name = "Denumire")]
        public string TipJob { get; set; }
        public ICollection<Angajat> Angajati { get; set; }
    }
}
