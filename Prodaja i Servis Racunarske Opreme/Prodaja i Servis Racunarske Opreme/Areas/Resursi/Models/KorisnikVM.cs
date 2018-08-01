using Prodaja_i_Servis_Racunarske_Opreme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Models
{
    public class KorisnikVM
    {
        public int id { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public bool Status { get; set; }

        [Required(ErrorMessage = "Potrebno unjeti ime")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Potrebno unjeti prezime")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Potrebno unjeti adresu")]
        public string Adresa { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Potrebno unjeti broj telefona")]
        public string BrojTelefona { get; set; }
        public char Spol { get; set; }

        [Required(ErrorMessage = "Potrebno unjeti username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Potrebno unjeti password")]
        [MinLength(6,ErrorMessage ="Password nije dovoljno dug")]
        public string Password { get; set; }

        public List<Grad> LGrad { get; set; }
        [Required(ErrorMessage = "Potrebno odabrati grad")]
        public int GradId { get; set; }
        public string NazivGrada { get; set; }

        public IEnumerable<SelectListItem> DDLG
        {
            get
            {
                List<SelectListItem> Izbor = new List<SelectListItem>();
                Izbor.Add(new SelectListItem { Text = "[GRAD]", Value = "" });
                Izbor.AddRange(LGrad.Select(x => new SelectListItem
                {
                    Text = x.Naziv,
                    Value = x.Id.ToString()
                }));
                return Izbor;
            }
        }
    }
}