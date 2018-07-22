using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodaja_i_Servis_Racunarske_Opreme.Helper
{
    public class LogiraniSes
    {

        public bool Korisnik { get; set; }
        public int LogiraniId { get; set; }
        public string Ime_Prezime { get; set; }

        public string UserName { get; set; }

        public string ZaduzenjeZaposlenika { get; set; }
        public bool StatusKorisnika { get; set; }


    }
}