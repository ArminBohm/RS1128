using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodaja_i_Servis_Racunarske_Opreme.Models
{
    public class Artikal
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }

        public virtual Proizvodjac Proizvodjac { get; set; }
        public int ProizvodjacId { get; set; }

        public virtual GrupaProizvoda GrupaProizvoda { get; set; }
        public int GrupaProizvodaId { get; set; }

        public virtual JediniceMjere JediniceMjere { get; set; }
        public int JedinicaMjereId { get; set; }

    }
}