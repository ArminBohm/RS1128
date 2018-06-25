using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodaja_i_Servis_Racunarske_Opreme.Models
{
    public class Skladiste
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }

        public virtual Artikal Artikal { get; set; }
        public int ArtikalId { get; set; }
    }
}