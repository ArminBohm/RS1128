using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodaja_i_Servis_Racunarske_Opreme.Models
{
    public class Racun
    {
        public int Id { get; set; }
        public string TipUsluge { get; set; }
        public DateTime DatumUsluge { get; set; }

        public virtual Osoba Osoba { get; set; }
        public int OsobaId { get; set; }

        public virtual NazivPlacanja NazivPlacanja { get; set; }
        public int NazivPlacanjaId { get; set; }

        public virtual Popust Popust { get; set; }
        public int PopustId { get; set; }

        public virtual EvidencijaDostave EvidencijaDostave { get; set; }
        public int? EvidencijaDostaveId { get; set; }


    }
}