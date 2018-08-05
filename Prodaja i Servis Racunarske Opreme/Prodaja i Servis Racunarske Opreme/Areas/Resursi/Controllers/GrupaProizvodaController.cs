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

    public class GrupaProizvodaController : Controller
    {
        // GET: Resursi/GrupaProizvoda
        MyContext CTX = new MyContext();
        [Pristup(Ovlasti = "Administrator,Prodavac,Serviser")]
        public ActionResult Index()
        {
            List<GrupaProizvoda> Model = CTX.GrupeProizvoda.ToList();

            return View(Model);
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Dodaj_GP()
        {
            GrupaProizvoda Model = new GrupaProizvoda();

            return View("Dodavanje_GP", Model);
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Spasi_GP(GrupaProizvoda Nova_GP)
        {
            bool Pronadjeno = false;
            if (!ModelState.IsValid)
            {
                return View("Dodavanje_GP", Nova_GP);
            }
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

            return JavaScript("window.location = '" + Url.Action("Index") + "'");
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Edituj_GP(int id)
        {
            GrupaProizvoda Model = CTX.GrupeProizvoda.Where(x => x.Id == id).FirstOrDefault();

            return View("Edituj_GP", Model);
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult SpasiIzmjenu_GP(GrupaProizvoda Podaci)
        {
            GrupaProizvoda Izmjenuti = CTX.GrupeProizvoda.Where(x => x.Id == Podaci.Id).FirstOrDefault();
            if (!ModelState.IsValid)
            {
                return View("Edituj_GP", Podaci);
            }
            Izmjenuti.Naziv = Podaci.Naziv;

            CTX.SaveChanges();

            return JavaScript("window.location = '" + Url.Action("Index") + "'");
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Brisanje_GP(int id)
        {
            try
            {
                CTX.GrupeProizvoda.Remove(CTX.GrupeProizvoda.Where(x => x.Id == id).FirstOrDefault());

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