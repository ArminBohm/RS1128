using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodaja_i_Servis_Racunarske_Opreme.Models
{
    public class Zaposlenik
    {
        public int Id { get; set; }
        public DateTime PocetakRadnogOdnosa { get; set; }
        public DateTime ZavrsetakRadnogOdnosa { get; set; }

        public virtual StrucnaSprema StrucnaSprema { get; set; }
        public int StrucnaSpremaId { get; set; }

        public Osoba Osoba { get; set; }

        public virtual Zaduzenje Zaduzenje { get; set; }
        public int ZaduzenjeId { get; set; }
    }
}