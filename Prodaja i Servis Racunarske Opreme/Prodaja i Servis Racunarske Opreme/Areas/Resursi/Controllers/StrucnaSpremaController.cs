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
    public class StrucnaSpremaController : Controller
    {
        // GET: Resursi/StrucnaSprema
        MyContext CTX = new MyContext();

        public ActionResult Index()
        {
            List<StrucnaSprema> Model = CTX.StrucneSpreme.ToList();

            return View(Model);
        }

        public ActionResult Dodaj_SP()
        {
            StrucnaSprema Model = new StrucnaSprema();

            return View("Dodavanje_SP", Model);
        }

        public ActionResult Spasi_SP(StrucnaSprema Nova_SP)
        {
            bool Pronadjeno = false;
            if (!ModelState.IsValid)
            {
                return View("Dodavanje_SP", Nova_SP);
            }
            foreach (StrucnaSprema JM in CTX.StrucneSpreme)
            {
                if (JM.Naziv == Nova_SP.Naziv)
                {
                    Pronadjeno = true;
                }
            }

            if (Pronadjeno == false)
            {
                CTX.StrucneSpreme.Add(Nova_SP);
                CTX.SaveChanges();
            }

            return JavaScript("window.location = '" + Url.Action("Index") + "'");
        }

        public ActionResult Edituj_SP(int id)
        {
            StrucnaSprema Model = CTX.StrucneSpreme.Where(x => x.Id == id).FirstOrDefault();

            return View("Edituj_SP", Model);
        }

        public ActionResult SpasiIzmjenu_SP(StrucnaSprema Podaci)
        {
            StrucnaSprema Izmjenuti = CTX.StrucneSpreme.Where(x => x.Id == Podaci.Id).FirstOrDefault();
            if (!ModelState.IsValid)
            {
                return View("Dodavanje_SP", Podaci);
            }
            Izmjenuti.Naziv = Podaci.Naziv;

            CTX.SaveChanges();

            return JavaScript("window.location = '" + Url.Action("Index") + "'");
        }

        public ActionResult Brisanje_SP(int id)
        {
            try
            {
                CTX.StrucneSpreme.Remove(CTX.StrucneSpreme.Where(x => x.Id == id).FirstOrDefault());

                CTX.SaveChanges();


            }
            catch (Exception B)
            {
                return RedirectToAction("../../Common/DelMsg");
            }
            return RedirectToAction("Index");

        }
    }
}