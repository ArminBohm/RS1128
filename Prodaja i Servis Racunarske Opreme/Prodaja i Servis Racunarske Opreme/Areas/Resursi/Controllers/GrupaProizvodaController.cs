using Prodaja_i_Servis_Racunarske_Opreme.DAL;
using Prodaja_i_Servis_Racunarske_Opreme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Controllers
{
    public class GrupaProizvodaController : Controller
    {
        // GET: Resursi/GrupaProizvoda
        MyContext CTX = new MyContext();

        public ActionResult Index()
        {
            List<GrupaProizvoda> Model = CTX.GrupeProizvoda.ToList();

            return View(Model);
        }

        public ActionResult Dodaj_GP()
        {
            GrupaProizvoda Model = new GrupaProizvoda();

            return View("Dodavanje_GP", Model);
        }

        public ActionResult Spasi_GP(GrupaProizvoda Nova_GP)
        {
            bool Pronadjeno = false;
            foreach (GrupaProizvoda JM in CTX.GrupeProizvoda)
            {
                if (JM.Naziv == Nova_GP.Naziv)
                {
                    Pronadjeno = true;
                }
            }

            if (Pronadjeno == false)
            {
                CTX.GrupeProizvoda.Add(Nova_GP);
                CTX.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edituj_GP(int id)
        {
            GrupaProizvoda Model = CTX.GrupeProizvoda.Where(x => x.Id == id).FirstOrDefault();

            return View("Edituj_GP", Model);
        }

        public ActionResult SpasiIzmjenu_GP(GrupaProizvoda Podaci)
        {
            GrupaProizvoda Izmjenuti = CTX.GrupeProizvoda.Where(x => x.Id == Podaci.Id).FirstOrDefault();
            Izmjenuti.Naziv = Podaci.Naziv;

            CTX.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Brisanje_GP(int id)
        {

            CTX.GrupeProizvoda.Remove(CTX.GrupeProizvoda.Where(x => x.Id == id).FirstOrDefault());

            CTX.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}