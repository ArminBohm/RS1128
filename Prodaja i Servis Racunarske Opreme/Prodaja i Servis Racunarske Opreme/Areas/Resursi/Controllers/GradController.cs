using Prodaja_i_Servis_Racunarske_Opreme.DAL;
using Prodaja_i_Servis_Racunarske_Opreme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Controllers
{
    public class GradController : Controller
    {
        // GET: Resursi/Grad
        MyContext CTX = new MyContext();

        public ActionResult Index()
        {
            List<Grad> Model = CTX.Gradovi.ToList();

            return View(Model);
        }

        public ActionResult Dodaj_G()
        {
            Grad Model = new Grad();

            return View("Dodavanje_G", Model);
        }

        public ActionResult Spasi_G(Grad Nova_G)
        {
            bool Pronadjeno = false;
            foreach (Grad JM in CTX.Gradovi)
            {
                if (JM.Naziv == Nova_G.Naziv)
                {
                    Pronadjeno = true;
                }
            }

            if (Pronadjeno == false)
            {
                CTX.Gradovi.Add(Nova_G);
                CTX.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edituj_G(int id)
        {
            Grad Model = CTX.Gradovi.Where(x => x.Id == id).FirstOrDefault();

            return View("Edituj_G", Model);
        }

        public ActionResult SpasiIzmjenu_G(Grad Podaci)
        {
            Grad Izmjenuti = CTX.Gradovi.Where(x => x.Id == Podaci.Id).FirstOrDefault();
            Izmjenuti.Naziv = Podaci.Naziv;

            CTX.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Brisanje_G(int id)
        {

            CTX.Gradovi.Remove(CTX.Gradovi.Where(x => x.Id == id).FirstOrDefault());

            CTX.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}