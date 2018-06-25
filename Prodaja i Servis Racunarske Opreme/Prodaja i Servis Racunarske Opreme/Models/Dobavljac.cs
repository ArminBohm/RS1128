using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodaja_i_Servis_Racunarske_Opreme.Models
{
    public class Dobavljac
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual Grad Grad { get; set; }
        public int GradId { get; set; }
    }
}