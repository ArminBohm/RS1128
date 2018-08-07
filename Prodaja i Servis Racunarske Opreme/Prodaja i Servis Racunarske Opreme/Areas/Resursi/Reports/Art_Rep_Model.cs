using Prodaja_i_Servis_Racunarske_Opreme.DAL;
using Prodaja_i_Servis_Racunarske_Opreme.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Reports
{
    public class Art_Rep_Model
    {
        public static MyContext CTX = new MyContext();

        public class Body
        {
            public string Naziv { get; set; }
            public float Cijena { get; set; }
            public string JedinicaMjere { get; set; }
            public string Grupa { get; set; }
            public string Proizvodjac { get; set; }

            
        }
        public class Header
        {
            public string Datum { get; set; }
            public string Naslov { get; set; }
            public string Autor { get; set; }

        }

        public static List<Body> ArtBody()
        {
            List<Body> LB = new List<Body>();

            LB = CTX.Artikli.Include(a => a.GrupaProizvoda)
                           .Include(a => a.JedinicaMjere)
                           .Include(a => a.Proizvodjac)
                           //.Where(z => z.)
                           .Select(x => new Body
                           {
                               Cijena = x.Cijena,
                               Grupa = x.GrupaProizvoda.Naziv,
                               JedinicaMjere = x.JedinicaMjere.Naziv,
                               Naziv = x.Naziv,
                               Proizvodjac = x.Proizvodjac.Naziv
                           }).ToList();
            return LB;
        }

        public static List<Header> ArtHeader()
        {
            List<Header> LH = new List<Header>();

            Header NoviH = new Header();
            NoviH.Datum = DateTime.Now.ToShortDateString();
            NoviH.Naslov = "Lista Artikala";
            LogiraniSes Logirani = (HttpContext.Current.Session["Logirani"] as LogiraniSes);
            NoviH.Autor = Logirani.Ime_Prezime;

            LH.Add(NoviH);
            return LH;
        }
    }
}