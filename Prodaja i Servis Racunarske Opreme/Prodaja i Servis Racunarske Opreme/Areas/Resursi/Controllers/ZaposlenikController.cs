using Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Models;
using Prodaja_i_Servis_Racunarske_Opreme.DAL;
using Prodaja_i_Servis_Racunarske_Opreme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Prodaja_i_Servis_Racunarske_Opreme.Helper;

namespace Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Controllers
{
    [Pristup(Ovlasti = "Administrator")]
    public class ZaposlenikController : Controller
    {
        // GET: Resursi/Korisnik
        MyContext CTX = new MyContext();

        public ActionResult Index()
        {
            List<ZaposlenikVM> Model = new List<ZaposlenikVM>();
            List<Zaposlenik> Podaci = CTX.Zaposlenici.Include(x => x.Osoba).ToList();

            Model.AddRange(Podaci.Select(x => new ZaposlenikVM
            {
                PocetakRadnogOdnosa = x.PocetakRadnogOdnosa,
                ZavrsetakRadnogOdnosa = x.ZavrsetakRadnogOdnosa,
                id = x.Id,
                Ime = x.Osoba.Ime,
                Prezime = x.Osoba.Prezime,
                GradId = x.Osoba.GradId,
                NazivGrada = x.Osoba.Grad.Naziv,
                Adresa = x.Osoba.Adresa,
                BrojTelefona = x.Osoba.BrojTelefona,
                Spol = x.Osoba.Spol,
                Email = x.Osoba.Email,
                Password = x.Osoba.Password,
                UserName = x.Osoba.UserName,
                LSPId = x.StrucnaSpremaId,
                SPNaziv = x.StrucnaSprema.Naziv,
                LZaduzenjeId = x.ZaduzenjeId,
                Zaduzenje = x.Zaduzenje.Naziv

            }));

            return View(Model);
        }

        public ActionResult Dodaj_Z()
        {
            ZaposlenikVM Model = new ZaposlenikVM();
            Model.LGrad = CTX.Gradovi.ToList();
            Model.LSP = CTX.StrucneSpreme.ToList();
            Model.LZaduzenje = CTX.Zaduzenja.ToList();

            Model.PocetakRadnogOdnosa = DateTime.Now;
            Model.ZavrsetakRadnogOdnosa = DateTime.Now;

            return View("Dodavanje_Z", Model);
        }

        public ActionResult Spasi_Z(ZaposlenikVM Nova_Z)
        {
            bool Pronadjeno = false;
            if (!ModelState.IsValid)
            {
                Nova_Z.LGrad = CTX.Gradovi.ToList();
                Nova_Z.PocetakRadnogOdnosa = DateTime.Now;
                Nova_Z.LSP = CTX.StrucneSpreme.ToList();
                Nova_Z.LZaduzenje = CTX.Zaduzenja.ToList();

                return View("Dodavanje_Z", Nova_Z);
            }
            foreach (Zaposlenik Z in CTX.Zaposlenici.Include(x => x.Osoba))
            {
                if (Z.Osoba.UserName == Nova_Z.UserName)
                {
                    Pronadjeno = true;
                }
            }

            if (Pronadjeno == false)
            {
                Zaposlenik Novi = new Zaposlenik();
                Novi.Osoba = new Osoba();

                Novi.PocetakRadnogOdnosa = Nova_Z.PocetakRadnogOdnosa;
                Novi.ZavrsetakRadnogOdnosa = Nova_Z.ZavrsetakRadnogOdnosa;
                Novi.StrucnaSpremaId = Nova_Z.LSPId;
                Novi.ZaduzenjeId = Nova_Z.LZaduzenjeId;

                Novi.Osoba.Ime = Nova_Z.Ime;
                Novi.Osoba.Prezime = Nova_Z.Prezime;
                Novi.Osoba.Spol = Nova_Z.Spol;
                Novi.Osoba.GradId = Nova_Z.GradId;
                Novi.Osoba.UserName = Nova_Z.UserName;
                Novi.Osoba.Password = Nova_Z.Password;
                Novi.Osoba.Adresa = Nova_Z.Adresa;
                Novi.Osoba.BrojTelefona = Nova_Z.BrojTelefona;
                Novi.Osoba.Email = Nova_Z.Email;



                CTX.Zaposlenici.Add(Novi);
                CTX.Osobe.Add(Novi.Osoba);
                CTX.SaveChanges();
            }

            return JavaScript("window.location = '" + Url.Action("Index") + "'");
        }

        public ActionResult Edituj_Z(int id)
        {
            ZaposlenikVM Model = new ZaposlenikVM();
            Zaposlenik Podaci = CTX.Zaposlenici.Where(x => x.Id == id).Include(x => x.Osoba).FirstOrDefault();

            Model.LGrad = CTX.Gradovi.ToList();
            Model.LSP = CTX.StrucneSpreme.ToList();
            Model.LZaduzenje = CTX.Zaduzenja.ToList();


            Model.Ime = Podaci.Osoba.Ime;
            Model.Prezime = Podaci.Osoba.Prezime;
            Model.Spol = Podaci.Osoba.Spol;
            Model.Adresa = Podaci.Osoba.Adresa;
            Model.BrojTelefona = Podaci.Osoba.BrojTelefona;
            Model.PocetakRadnogOdnosa = Podaci.PocetakRadnogOdnosa;
            Model.ZavrsetakRadnogOdnosa = Podaci.ZavrsetakRadnogOdnosa;
            Model.Email = Podaci.Osoba.Email;
            Model.GradId = Podaci.Osoba.GradId;
            Model.Password = Podaci.Osoba.Password;
            Model.UserName = Podaci.Osoba.UserName;
            Model.LSPId = Podaci.StrucnaSpremaId;
            Model.LZaduzenjeId = Podaci.ZaduzenjeId;


            return View("Edituj_Z", Model);
        }

        public ActionResult SpasiIzmjenu_Z(ZaposlenikVM Podaci)
        {

            if (!ModelState.IsValid)
            {
                Podaci.LGrad = CTX.Gradovi.ToList();
                Podaci.PocetakRadnogOdnosa = Podaci.PocetakRadnogOdnosa;
                Podaci.LSP = CTX.StrucneSpreme.ToList();
                Podaci.LZaduzenje = CTX.Zaduzenja.ToList(); 

                return View("Edituj_Z", Podaci);
            }
            Zaposlenik Izmjenuti = CTX.Zaposlenici.Where(x => x.Id == Podaci.id).Include(x => x.Osoba).FirstOrDefault();
            Izmjenuti.Osoba.Ime = Podaci.Ime;
            Izmjenuti.Osoba.Prezime = Podaci.Prezime;
            Izmjenuti.Osoba.Spol = Podaci.Spol;
            Izmjenuti.Osoba.Adresa = Podaci.Adresa;
            Izmjenuti.Osoba.BrojTelefona = Podaci.BrojTelefona;
            Izmjenuti.PocetakRadnogOdnosa = Podaci.PocetakRadnogOdnosa;
            Izmjenuti.ZavrsetakRadnogOdnosa = Podaci.ZavrsetakRadnogOdnosa;
            Izmjenuti.Osoba.Email = Podaci.Email;
            Izmjenuti.Osoba.GradId = Podaci.GradId;
            Izmjenuti.Osoba.Password = Podaci.Password;
            Izmjenuti.Osoba.UserName = Podaci.UserName;
            Izmjenuti.StrucnaSpremaId = Podaci.LSPId;
            Izmjenuti.ZaduzenjeId = Podaci.LZaduzenjeId;

            CTX.SaveChanges();

            return JavaScript("window.location = '" + Url.Action("Index") + "'");
        }

        public ActionResult Brisanje_Z(int id)
        {
            try
            {
                CTX.Osobe.Remove(CTX.Osobe.Where(x => x.Id == id).FirstOrDefault());
                CTX.Zaposlenici.Remove(CTX.Zaposlenici.Where(x => x.Id == id).FirstOrDefault());

                CTX.SaveChanges();

            }
            catch (Exception)
            {
                return RedirectToAction("../../Common/DelMsg");
            }
            return JavaScript("window.location = '" + Url.Action("Index") + "'");
        }
    }
}