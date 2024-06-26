using System.ComponentModel.DataAnnotations;

namespace FormCinema.Models
{
    public class Biglietto
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Inserire il nome")]
        public string FirstName { get; set; }
        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Inserire il cognome")]
        public string LastName { get; set; }
        [Display(Name = "Tariffa")]
        public char Tariffa { get; set; }
        [Display(Name = "Sala")]
        public string Sala { get; set; }
    }
}
