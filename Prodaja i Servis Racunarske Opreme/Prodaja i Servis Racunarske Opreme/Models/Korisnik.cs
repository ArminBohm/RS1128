using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodaja_i_Servis_Racunarske_Opreme.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public bool Status { get; set; }

        public Osoba Osoba { get; set; }
    }
}