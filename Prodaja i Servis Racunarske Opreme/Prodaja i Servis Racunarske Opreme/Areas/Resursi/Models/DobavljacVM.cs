using Prodaja_i_Servis_Racunarske_Opreme.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Models
{
    public class DobavljacVM
    {

        public int IdDobavljaca { get; set; }
        [Required (ErrorMessage = "Obavezno unjeti naziv dobavljaca")]
        public string Naziv { get; set; }

        public List<Grad> Lgradovi { get; set; }
        [Required(ErrorMessage = "Obavezno izabrati grad")]
        public int GradId { get; set; }

        public string NazivGrada { get; set; }


        public IEnumerable<SelectListItem> DDLG { get
            {
                List<SelectListItem> Izbor = new List<SelectListItem>();

                Izbor.Add(new SelectListItem { Value = "", Text = "[ODABERITE GRAD]" });
                Izbor.AddRange(Lgradovi.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv

                }));
                return Izbor;
            } }

    }
}