using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodaja_i_Servis_Racunarske_Opreme.Models
{
    public class Usluga
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }
    }
}