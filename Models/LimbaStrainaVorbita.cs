using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pop_Stefana_Proiect.Models
{
    public class LimbaStrainaVorbita
    {
        public int ID { get; set; }
        public int AngajatID { get; set; }
        public Angajat Angajat { get; set; }
        public int LimbaStrainaID { get; set; }
        public LimbaStraina LimbaStraina { get; set; }
    }
}
