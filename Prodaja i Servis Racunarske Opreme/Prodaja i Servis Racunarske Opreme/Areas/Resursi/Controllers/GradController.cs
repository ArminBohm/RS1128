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

    public class GradController : Controller
    {
        // GET: Resursi/Grad
        MyContext CTX = new MyContext();
        [Pristup(Ovlasti = "Administrator,Prodavac,Serviser")]
        public ActionResult Index()
        {
            List<Grad> Model = CTX.Gradovi.ToList();

            return View(Model);
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Dodaj_G()
        {
            Grad Model = new Grad();

            return View("Dodavanje_G", Model);
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Spasi_G(Grad Nova_G)
        {
            bool Pronadjeno = false;
            if (!ModelState.IsValid)
            {
                return View("Dodavanje_G", Nova_G);
            }
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

            return JavaScript("window.location = '" + Url.Action("Index") + "'");
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Edituj_G(int id)
        {


            Grad Model = CTX.Gradovi.Where(x => x.Id == id).FirstOrDefault();

            return View("Edituj_G", Model);
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult SpasiIzmjenu_G(Grad Podaci)
        {

            //Grad Gr = CTX.Gradovi
            //    .Where(x => x.Naziv == Podaci.Naziv)
            //    .Where(x => x.Id != Podaci.Id)
            //    .FirstOrDefault();
            //if(Gr != null)
            //{
            //    return RedirectToAction("Index");
            //}
            if (!ModelState.IsValid)
            {
                return View("Edituj_G", Podaci);
            }
            foreach (Grad G in CTX.Gradovi)
            {
                if (G.Naziv == Podaci.Naziv && G.Id != Podaci.Id)
                {
                    return RedirectToAction("Index");
                }
            }


            Grad Izmjenuti = CTX.Gradovi.Where(x => x.Id == Podaci.Id).FirstOrDefault();
            Izmjenuti.Naziv = Podaci.Naziv;

            CTX.SaveChanges();

            return JavaScript("window.location = '" + Url.Action("Index") + "'");
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Brisanje_G(int id)
        {
            try
            {
                CTX.Gradovi.Remove(CTX.Gradovi.Where(x => x.Id == id).FirstOrDefault());

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