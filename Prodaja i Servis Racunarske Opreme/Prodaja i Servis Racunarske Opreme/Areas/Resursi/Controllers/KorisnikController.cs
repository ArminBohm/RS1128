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
                Novi.Osoba.GradId = Nova_K.GradId;
                Novi.Osoba.UserName = Nova_K.UserName;
                Novi.Osoba.Password = Nova_K.Password;
                Novi.Osoba.Adresa = Nova_K.Adresa;
                Novi.Osoba.BrojTelefona = Nova_K.BrojTelefona;
                Novi.Osoba.Email = Nova_K.Email;


                CTX.Korisnici.Add(Novi);
                CTX.Osobe.Add(Novi.Osoba);
                CTX.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edituj_K(int id)
        {
            KorisnikVM Model = new KorisnikVM();
            Korisnik Podaci = CTX.Korisnici.Where(x => x.Id == id).Include(x=> x.Osoba).FirstOrDefault();

            Model.LGrad = CTX.Gradovi.ToList();


            Model.Ime = Podaci.Osoba.Ime;
            Model.Prezime = Podaci.Osoba.Prezime;
            Model.Spol = Podaci.Osoba.Spol;
            Model.Adresa = Podaci.Osoba.Adresa;
            Model.BrojTelefona = Podaci.Osoba.BrojTelefona;
            Model.DatumRegistracije = Podaci.DatumRegistracije;
            Model.Email = Podaci.Osoba.Email;
            Model.GradId = Podaci.Osoba.GradId;
            Model.Password = Podaci.Osoba.Password;
            Model.UserName = Podaci.Osoba.UserName;



            return View("Edituj_K", Model);
        }

        public ActionResult SpasiIzmjenu_K(KorisnikVM Podaci)
        {
            Korisnik Izmjenuti = CTX.Korisnici.Where(x => x.Id == Podaci.id).Include(x=> x.Osoba).FirstOrDefault();
            Izmjenuti.Osoba.Ime = Podaci.Ime;
            Izmjenuti.Osoba.Prezime = Podaci.Prezime;
            Izmjenuti.Osoba.Spol = Podaci.Spol;
            Izmjenuti.Osoba.Adresa = Podaci.Adresa;
            Izmjenuti.Osoba.BrojTelefona = Podaci.BrojTelefona;
            Izmjenuti.DatumRegistracije = Podaci.DatumRegistracije;
            Izmjenuti.Osoba.Email = Podaci.Email;
            Izmjenuti.Osoba.GradId = Podaci.GradId;
            Izmjenuti.Osoba.Password = Podaci.Password;
            Izmjenuti.Osoba.UserName = Podaci.UserName;

            CTX.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Brisanje_K(int id)
        {
            CTX.Osobe.Remove(CTX.Osobe.Where(x => x.Id == id).FirstOrDefault());
            CTX.Korisnici.Remove(CTX.Korisnici.Where(x => x.Id == id).FirstOrDefault());

            CTX.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}