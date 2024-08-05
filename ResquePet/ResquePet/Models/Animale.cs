using System.ComponentModel.DataAnnotations;

namespace ResquePet.Models
{
    public class Animale
    {
        [Key]
        public int IdAnimale { get; set; }
        public string Nome { get; set; }
        public string tipoAnimale { get; set; }

        public string coloreMantello { get; set; }

        public DateOnly dataNascita { get; set; }

        //public DateOnly DataRegistrazione { get; set; }

        public bool isMicrochipped { get; set; }

        public int? MicrochipID { get; set; }

        public int? IdUtente { get; set; }

        public Utente? utente { get; set; }
    }

    
}


