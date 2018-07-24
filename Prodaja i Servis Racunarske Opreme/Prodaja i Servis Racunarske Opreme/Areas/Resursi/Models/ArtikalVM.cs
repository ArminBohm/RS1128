using Prodaja_i_Servis_Racunarske_Opreme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Models
{
    public class ArtikalVM
    {
        public int IdArtikla { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }

        public List<JedinicaMjere> LJM { get; set; }
        public int LJMId { get; set; }
        public string JedMjere { get; set; }
        
        public List<Proizvodjac> LPro { get; set; }
        public int ProId { get; set; }
        public string Proizvodjac { get; set; }

        public List<GrupaProizvoda> LGP { get; set; }
        public int GPId { get; set; }
        public string GrupaProizvoda { get; set; }


        public IEnumerable<SelectListItem> DDLJM
        {
            get
            {
                List<SelectListItem> Izbor = new List<SelectListItem>();

                Izbor.Add(new SelectListItem { Value = "", Text = "[JEDINICA MJERE]" });
                Izbor.AddRange(LJM.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv

                }));
                return Izbor;
            }
        }
        public IEnumerable<SelectListItem> DDLPro
        {
            get
            {
                List<SelectListItem> Izbor = new List<SelectListItem>();

                Izbor.Add(new SelectListItem { Value = "", Text = "[PROIZVODJAC]" });
                Izbor.AddRange(LPro.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv

                }));
                return Izbor;
            }
        }
        public IEnumerable<SelectListItem> DDLGP
        {
            get
            {
                List<SelectListItem> Izbor = new List<SelectListItem>();

                Izbor.Add(new SelectListItem { Value = "", Text = "[GRUPA PROIZVODA]" });
                Izbor.AddRange(LGP.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv

                }));
                return Izbor;
            }
        }

    }
}