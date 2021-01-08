using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pop_Stefana_Proiect.Models
{
    public class Departament
    {
        public int ID { get; set; }
        [Display(Name = "Denumire")]
        public string NumeDepartament { get; set; }
        public ICollection<Angajat> Angajati { get; set; }
    }
}
