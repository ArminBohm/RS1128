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
    public class ProizvodjacController : Controller
    {
        // GET: Resursi/Proizvodjac
        MyContext CTX = new MyContext();
        [Pristup(Ovlasti = "Administrator,Prodavac,Serviser")]
        public ActionResult Index()
        {
            List<Proizvodjac> Model = CTX.Proizvodjaci.ToList();

            return View(Model);
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Dodaj_P()
        {
            Proizvodjac Model = new Proizvodjac();

            return View("Dodavanje_P", Model);
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Spasi_P(Proizvodjac Nova_P)
        {
            bool Pronadjeno = false;
            if (!ModelState.IsValid)
            {
                return View("Dodavanje_P", Nova_P);
            }
            foreach (Proizvodjac JM in CTX.Proizvodjaci)
            {
                if (JM.Naziv == Nova_P.Naziv)
                {
                    Pronadjeno = true;
                }
            }

            if (Pronadjeno == false)
            {
                CTX.Proizvodjaci.Add(Nova_P);
                CTX.SaveChanges();
            }

            return JavaScript("window.location = '" + Url.Action("Index") + "'");
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Edituj_P(int id)
        {
            Proizvodjac Model = CTX.Proizvodjaci.Where(x => x.Id == id).FirstOrDefault();

            return View("Edituj_P", Model);
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult SpasiIzmjenu_P(Proizvodjac Podaci)
        {
            Proizvodjac Izmjenuti = CTX.Proizvodjaci.Where(x => x.Id == Podaci.Id).FirstOrDefault();
            if (!ModelState.IsValid)
            {
                return View("Edituj_P", Podaci);
            }
            Izmjenuti.Naziv = Podaci.Naziv;

            CTX.SaveChanges();

            return JavaScript("window.location = '" + Url.Action("Index") + "'");
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Brisanje_P(int id)
        {
            try
            {
                CTX.Proizvodjaci.Remove(CTX.Proizvodjaci.Where(x => x.Id == id).FirstOrDefault());

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