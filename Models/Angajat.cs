using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pop_Stefana_Proiect.Models
{
    public class Angajat
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele angajatului trebuie sa fie de forma 'Nume Prenume'"), Required,
StringLength(50, MinimumLength = 3)]
        [Display(Name = "Nume Prenume")]
        public string NumePrenume { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataAngajarii { get; set; }
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email-ul trebuie sa fie de forma 'x@y.z'"), Required]
        public string Email { get; set; }
        [Required, RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Nr de telefon trebuie sa aiba 10 cifre")]
        public string NrTelefon { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Salariu { get; set; }
        public int DepartamentID { get; set; }
        public Departament Departament { get; set; }
        public int JobID { get; set; }
        public Job Job { get; set; }
        public ICollection<LimbaStrainaVorbita> LimbiStraineVorbite { get; set; }
    }
}
