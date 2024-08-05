using System.ComponentModel.DataAnnotations;

namespace ResquePet.Models
{
    public class Utente
    {
        [Key] 
        public int IdUtente { get; set; }

        public string username { get; set; }

        public string password { get; set; }    

        public string Nome { get; set; }

        public string Cognome { get; set; }

        public Animale? animale { get; set; }

    }
}