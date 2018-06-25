using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Prodaja_i_Servis_Racunarske_Opreme.Models
{
    public class Osoba
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string BrojTelefona { get; set; }
        public char Spol { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual Grad Grad { get; set; }
        public int GradId { get; set; }

        public Korisnik Korisnik { get; set; }
        public Zaposlenik Zaposlenik { get; set; }

        
    }
}