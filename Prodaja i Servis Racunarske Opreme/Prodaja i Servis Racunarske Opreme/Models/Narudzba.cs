using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodaja_i_Servis_Racunarske_Opreme.Models
{
    public class Narudzba
    {
        public int Id { get; set; }
        public DateTime DatumNaredzbe { get; set; }

        public virtual Dobavljac Dobavljac { get; set; }
        public int DobavljacId { get; set; }

        public virtual Zaposlenik Zaposlenik{ get; set; }
        public int ZaposlenikId { get; set; }
    }
}