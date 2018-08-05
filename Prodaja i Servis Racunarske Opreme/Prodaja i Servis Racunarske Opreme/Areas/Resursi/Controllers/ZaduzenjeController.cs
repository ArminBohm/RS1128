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
    [Pristup(Ovlasti = "Administrator")]
    public class ZaduzenjeController : Controller
    {
        // GET: Resursi/Zaduzenje
        MyContext CTX = new MyContext();

        public ActionResult Index()
        {
            List<Zaduzenje> Model = CTX.Zaduzenja.ToList();
            return View(Model);
        }

        public ActionResult Dodaj_Z()
        {
            Zaduzenje Model = new Zaduzenje();

            return View("Dodavanje_Z", Model);
        }

        public ActionResult Spasi_Z(Zaduzenje Nova_Z)
        {
            bool Pronadjeno = false;
            foreach (Zaduzenje Z in CTX.Zaduzenja)
            {
                if (Z.Naziv == Nova_Z.Naziv)
                {
                    Pronadjeno = true;
                }
            }

            if (Pronadjeno == false)
            {
                CTX.Zaduzenja.Add(Nova_Z);
                CTX.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edituj_Z(int id)
        {
            Zaduzenje Model = CTX.Zaduzenja.Where(x => x.Id == id).FirstOrDefault();

            return View("Edituj_Z", Model);
        }

        public ActionResult SpasiIzmjenu_Z(Zaduzenje Podaci)
        {
            Zaduzenje Izmjenuti = CTX.Zaduzenja.Where(x => x.Id == Podaci.Id).FirstOrDefault();
            Izmjenuti.Naziv = Podaci.Naziv;

            CTX.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Brisanje_Z(int id)
        {
            try
            {
                CTX.Zaduzenja.Remove(CTX.Zaduzenja.Where(x => x.Id == id).FirstOrDefault());

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