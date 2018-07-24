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

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string BrojTelefona { get; set; }
        public char Spol { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<Grad> LGrad { get; set; }
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