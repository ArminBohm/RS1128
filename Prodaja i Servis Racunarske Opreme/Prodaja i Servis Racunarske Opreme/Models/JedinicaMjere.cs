using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prodaja_i_Servis_Racunarske_Opreme.Models
{
    public class JedinicaMjere
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Potrebno unjeti jedinicu mjere")]
        public string Naziv { get; set; }
    }
}