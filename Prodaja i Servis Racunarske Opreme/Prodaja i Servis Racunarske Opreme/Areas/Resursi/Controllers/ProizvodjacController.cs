using Prodaja_i_Servis_Racunarske_Opreme.DAL;
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

        public ActionResult Index()
        {
            List<Proizvodjac> Model = CTX.Proizvodjaci.ToList();

            return View(Model);
        }

        public ActionResult Dodaj_P()
        {
            Proizvodjac Model = new Proizvodjac();

            return View("Dodavanje_P", Model);
        }

        public ActionResult Spasi_P(Proizvodjac Nova_P)
        {
            bool Pronadjeno = false;
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

            return RedirectToAction("Index");
        }

        public ActionResult Edituj_P(int id)
        {
            Proizvodjac Model = CTX.Proizvodjaci.Where(x => x.Id == id).FirstOrDefault();

            return View("Edituj_P", Model);
        }

        public ActionResult SpasiIzmjenu_P(Proizvodjac Podaci)
        {
            Proizvodjac Izmjenuti = CTX.Proizvodjaci.Where(x => x.Id == Podaci.Id).FirstOrDefault();
            Izmjenuti.Naziv = Podaci.Naziv;

            CTX.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Brisanje_P(int id)
        {

            CTX.Proizvodjaci.Remove(CTX.Proizvodjaci.Where(x => x.Id == id).FirstOrDefault());

            CTX.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}