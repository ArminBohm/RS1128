using Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Models;
using Prodaja_i_Servis_Racunarske_Opreme.DAL;
using Prodaja_i_Servis_Racunarske_Opreme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Controllers
{
    public class KorisnikController : Controller
    {
        // GET: Resursi/Korisnik
        MyContext CTX = new MyContext();

        public ActionResult Index()
        {
            List<KorisnikVM> Model = new List<KorisnikVM>();
            List<Korisnik> Podaci = CTX.Korisnici.Include(x => x.Osoba).ToList();
            
            Model.AddRange(Podaci.Select(x => new KorisnikVM
            {
                DatumRegistracije = x.DatumRegistracije,
                id = x.Id,
                Status = x.Status,
                Ime = x.Osoba.Ime,
                Prezime = x.Osoba.Prezime,
                GradId = x.Osoba.GradId,
                NazivGrada = x.Osoba.Grad.Naziv,
                Adresa = x.Osoba.Adresa,
                BrojTelefona = x.Osoba.BrojTelefona,
                Spol = x.Osoba.Spol,
                Email = x.Osoba.Email,
                Password = x.Osoba.Password,
                UserName = x.Osoba.UserName
            }));

            return View(Model);
        }

        public ActionResult Dodaj_K()
        {
            KorisnikVM Model = new KorisnikVM();
            Model.LGrad = CTX.Gradovi.ToList();
            Model.DatumRegistracije = DateTime.Now;
            return View("Dodavanje_K", Model);
        }

        public ActionResult Spasi_K(KorisnikVM Nova_K)
        {
            bool Pronadjeno = false;
            foreach (Korisnik A in CTX.Korisnici)
            {
                if (A.Osoba.UserName == Nova_K.UserName)
                {
                    Pronadjeno = true;
                }
            }

            if (Pronadjeno == false)
            {
                Korisnik Novi = new Korisnik();
                Novi.Osoba = new Osoba();

                Novi.DatumRegistracije = Nova_K.DatumRegistracije;
                Novi.Status = Nova_K.Status;
                Novi.Osoba.Ime = Nova_K.Ime;
                Novi.Osoba.Prezime = Nova_K.Prezime;
                Novi.Osoba.Spol = Nova_K.Spol;
                //Novi.Osoba.Grad.Naziv = Nova_K.NazivGrada;
                Novi.Osoba.GradId = Nova_K.GradId;
                Novi.Osoba.UserName = Nova_K.UserName;
                Novi.Osoba.Password = Nova_K.Password;



                CTX.Korisnici.Add(Novi);
                CTX.Osobe.Add(Novi.Osoba);
                CTX.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edituj_A(int id)
        {
            ArtikalVM Model = new ArtikalVM();
            Artikal Podaci = CTX.Artikli.Where(x => x.Id == id).FirstOrDefault();

            Model.LGP = CTX.GrupeProizvoda.ToList();
            Model.LJM = CTX.JediniceMjere.ToList();
            Model.LPro = CTX.Proizvodjaci.ToList();



            Model.LJMId = Podaci.JedinicaMjereId;
            Model.ProId = Podaci.ProizvodjacId;
            Model.GPId = Podaci.GrupaProizvodaId;
            Model.Naziv = Podaci.Naziv;
            Model.Cijena = Podaci.Cijena;
            Model.IdArtikla = Podaci.Id;
            return View("Edituj_A", Model);
        }

        public ActionResult SpasiIzmjenu_A(ArtikalVM Podaci)
        {
            Artikal Izmjenuti = CTX.Artikli.Where(x => x.Id == Podaci.IdArtikla).FirstOrDefault();
            Izmjenuti.Naziv = Podaci.Naziv;
            Izmjenuti.Cijena = Podaci.Cijena;
            Izmjenuti.GrupaProizvodaId = Podaci.GPId;
            Izmjenuti.JedinicaMjereId = Podaci.LJMId;
            Izmjenuti.ProizvodjacId = Podaci.ProId;

            CTX.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Brisanje_A(int id)
        {

            CTX.Artikli.Remove(CTX.Artikli.Where(x => x.Id == id).FirstOrDefault());

            CTX.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}