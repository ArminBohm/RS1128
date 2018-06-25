using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodaja_i_Servis_Racunarske_Opreme.Models
{
    public class Popust
    {
        public int Id { get; set; }
        public float Iznos { get; set; }
        public string Opis { get; set; }
    }
}