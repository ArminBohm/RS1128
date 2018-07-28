using Prodaja_i_Servis_Racunarske_Opreme.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Models
{
    public class ArtikalVM
    {
        public int IdArtikla { get; set; }
        [Required(ErrorMessage = "Obavezan unos naziva artikla") ]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Obavezan unos cijene")]
        public float Cijena { get; set; }

        public List<JedinicaMjere> LJM { get; set; }
        [Required (ErrorMessage = "Obavezno Izabrati jedinicu mjere")]
        public int LJMId { get; set; }
        public string JedMjere { get; set; }
        
        public List<Proizvodjac> LPro { get; set; }
        [Required(ErrorMessage ="Obavezno izabrati proizvodjaca")]
        public int ProId { get; set; }
        public string Proizvodjac { get; set; }

        public List<GrupaProizvoda> LGP { get; set; }
        [Required(ErrorMessage = "Obavezno izabrati Grupu u koju proizvod spada")]
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