using Prodaja_i_Servis_Racunarske_Opreme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Models
{
    public class ZaposlenikVM
    {
        public int id { get; set; }
        public DateTime PocetakRadnogOdnosa { get; set; }
        public DateTime? ZavrsetakRadnogOdnosa { get; set; }

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
        [Required(ErrorMessage = "Potrebno unjeti usernaem")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Potrebno unjeti password")]
        [MinLength(6, ErrorMessage = "Password nije dovoljno dug")]
        public string Password { get; set; }

        public List<Grad> LGrad { get; set; }
        [Required(ErrorMessage = "Potrebno odabrati grad")]
        public int GradId { get; set; }
        public string NazivGrada { get; set; }

        public List<StrucnaSprema> LSP { get; set; }
        [Required(ErrorMessage = "Potrebno odabrati strucnu spremu")]
        public int LSPId { get; set; }
        public string SPNaziv { get; set; }

        public List<Zaduzenje> LZaduzenje { get; set; }
        [Required(ErrorMessage = "Potrebno odabrati zaduzenje")]
        public int LZaduzenjeId { get; set; }
        public string Zaduzenje { get; set; }

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
        public IEnumerable<SelectListItem> DDLSP
        {
            get
            {
                List<SelectListItem> Izbor = new List<SelectListItem>();
                Izbor.Add(new SelectListItem { Text = "[STRUCNA SPREMA]", Value = "" });
                Izbor.AddRange(LSP.Select(x => new SelectListItem
                {
                    Text = x.Naziv,
                    Value = x.Id.ToString()
                }));
                return Izbor;
            }
        }
        public IEnumerable<SelectListItem> DDLZ
        {
            get
            {
                List<SelectListItem> Izbor = new List<SelectListItem>();
                Izbor.Add(new SelectListItem { Text = "[ZADUZENJE]", Value = "" });
                Izbor.AddRange(LZaduzenje.Select(x => new SelectListItem
                {
                    Text = x.Naziv,
                    Value = x.Id.ToString()
                }));
                return Izbor;
            }
        }
    }
}