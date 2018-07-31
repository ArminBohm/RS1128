using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prodaja_i_Servis_Racunarske_Opreme.Models
{
    public class Proizvodjac
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Potrebno unjeti proizvodjaca")]
        public string Naziv { get; set; }
    }
}