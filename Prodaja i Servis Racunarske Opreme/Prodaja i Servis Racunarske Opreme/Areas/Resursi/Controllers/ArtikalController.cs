using Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Models;
using Prodaja_i_Servis_Racunarske_Opreme.DAL;
using Prodaja_i_Servis_Racunarske_Opreme.Helper;
using Prodaja_i_Servis_Racunarske_Opreme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Controllers
{
    public class ArtikalController : Controller
    {
        // GET: Resursi/Artikal
        MyContext CTX = new MyContext();
        [Pristup(Ovlasti = "Administrator,Prodavac,Serviser")]
        public ActionResult Index()
        {
            List<ArtikalVM> Model = new List<ArtikalVM>();
            List<Artikal> Podaci = CTX.Artikli.ToList();
            Model.AddRange(Podaci.Select(x => new ArtikalVM
            {
               Cijena = x.Cijena,
               Naziv = x.Naziv,
               IdArtikla = x.Id,
               LJMId = x.JedinicaMjereId,
               ProId = x.ProizvodjacId,
               JedMjere = x.JedinicaMjere.Naziv,
               GrupaProizvoda = x.GrupaProizvoda.Naziv,
               Proizvodjac = x.Proizvodjac.Naziv
            }));

            return View(Model);
        }
        [Pristup(Ovlasti = "Administrator,Prodavac")]
        public ActionResult Dodaj_A()
        {
            ArtikalVM Model = new ArtikalVM();
            Model.LGP = CTX.GrupeProizvoda.ToList();
            Model.LJM = CTX.JediniceMjere.ToList();
            Model.LPro = CTX.Proizvodjaci.ToList();

            return View("Dodavanje_A", Model);
        }
        [Pristup(Ovlasti = "Administrator")]

        public ActionResult Spasi_A(ArtikalVM Nova_A)
        {
            if (!ModelState.IsValid)
            {
                Nova_A.LGP = CTX.GrupeProizvoda.ToList();
                Nova_A.LJM = CTX.JediniceMjere.ToList();
                Nova_A.LPro = CTX.Proizvodjaci.ToList();

                return View("Dodavanje_A", Nova_A);
            }

            bool Pronadjeno = false;
            foreach (Artikal A in CTX.Artikli)
            {
                if (A.Naziv == Nova_A.Naziv)
                {
                    Pronadjeno = true;
                }
            }

            if (Pronadjeno == false)
            {
                Artikal Novi = new Artikal();
                Novi.Naziv = Nova_A.Naziv;
                Novi.Cijena = Nova_A.Cijena;
                Novi.GrupaProizvodaId = Nova_A.GPId;
                Novi.JedinicaMjereId = Nova_A.LJMId;
                Novi.ProizvodjacId = Nova_A.ProId;
                CTX.Artikli.Add(Novi);
                CTX.SaveChanges();
            }

            return JavaScript("window.location = '" + Url.Action("Index") + "'");
        }

        [Pristup(Ovlasti = "Administrator")]
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
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult SpasiIzmjenu_A(ArtikalVM Podaci)
        {

            if (!ModelState.IsValid)
            {
                Podaci.LGP = CTX.GrupeProizvoda.ToList();
                Podaci.LJM = CTX.JediniceMjere.ToList();
                Podaci.LPro = CTX.Proizvodjaci.ToList();

                return View("Edituj_A", Podaci);
            }
            Artikal Izmjenuti = CTX.Artikli.Where(x => x.Id == Podaci.IdArtikla).FirstOrDefault();
            Izmjenuti.Naziv = Podaci.Naziv;
            Izmjenuti.Cijena = Podaci.Cijena;
            Izmjenuti.GrupaProizvodaId = Podaci.GPId;
            Izmjenuti.JedinicaMjereId = Podaci.LJMId;
            Izmjenuti.ProizvodjacId = Podaci.ProId;

            CTX.SaveChanges();

            return JavaScript("window.location = '" + Url.Action("Index") + "'");
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Brisanje_A(int id)
        {

            CTX.Artikli.Remove(CTX.Artikli.Where(x => x.Id == id).FirstOrDefault());

            CTX.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}