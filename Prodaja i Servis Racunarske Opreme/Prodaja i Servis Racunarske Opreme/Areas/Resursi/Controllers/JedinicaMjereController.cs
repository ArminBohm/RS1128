using Prodaja_i_Servis_Racunarske_Opreme.DAL;
using Prodaja_i_Servis_Racunarske_Opreme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Controllers
{
    public class JedinicaMjereController : Controller
    {
        MyContext CTX = new MyContext();
        // GET: Resursi/JedinicaMjere
        public ActionResult Index()
        {
            List<JedinicaMjere> Model = CTX.JediniceMjere.ToList();

            return View(Model);
        }

        public ActionResult Dodaj_JM()
        {
            JedinicaMjere Model = new JedinicaMjere();

            return View("Dodavanje_JM", Model);
        }

        public ActionResult Spasi_JM(JedinicaMjere Nova_JM)
        {
            bool Pronadjeno = false;
            foreach(JedinicaMjere JM in CTX.JediniceMjere)
            {
                if(JM.Naziv == Nova_JM.Naziv)
                {
                    Pronadjeno = true;
                }
            }

            if(Pronadjeno == false)
            {
                CTX.JediniceMjere.Add(Nova_JM);
                CTX.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edituj_JM(int id)
        {
            JedinicaMjere Model = CTX.JediniceMjere.Where(x => x.Id == id).FirstOrDefault();

            return View("Edituj_JM", Model);
        }

        public ActionResult SpasiIzmjenu_JM (JedinicaMjere Podaci)
        {
            JedinicaMjere Izmjenuti = CTX.JediniceMjere.Where(x => x.Id == Podaci.Id).FirstOrDefault();
            Izmjenuti.Naziv = Podaci.Naziv;

            CTX.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Brisanje_JM (int id)
        {

            CTX.JediniceMjere.Remove(CTX.JediniceMjere.Where(x => x.Id == id).FirstOrDefault());

            CTX.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}