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
    public class DobavljacController : Controller
    {
        // GET: Resursi/Dobavljac
        MyContext CTX = new MyContext();
        [Pristup(Ovlasti = "Administrator,Prodavac,Servise")]
        public ActionResult Index()
        {
            List<DobavljacVM> Model = new List<DobavljacVM>();
            List<Dobavljac> Podaci = CTX.Dobavljaci.ToList();
            Model.AddRange(Podaci.Select(x => new DobavljacVM
            {
                NazivGrada = x.Grad.Naziv,
                GradId = x.GradId,
                IdDobavljaca = x.Id,
                Naziv = x.Naziv
            }));

            return View(Model);
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Dodaj_D()
        {
            DobavljacVM Model = new DobavljacVM();
            Model.Lgradovi = CTX.Gradovi.ToList();

            return View("Dodavanje_D", Model);
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Spasi_D(DobavljacVM Nova_D)
        {
            bool Pronadjeno = false;
            foreach (Dobavljac D in CTX.Dobavljaci)
            {
                if (D.Naziv == Nova_D.Naziv)
                {
                    Pronadjeno = true;
                }
            }
            if (!ModelState.IsValid)
            {
                Nova_D.Lgradovi = CTX.Gradovi.ToList();
                return View("Dodavanje_D", Nova_D);
            }
            if (Pronadjeno == false)
            {
                Dobavljac Novi = new Dobavljac();
                Novi.Naziv = Nova_D.Naziv;
                Novi.GradId = Nova_D.GradId;
                CTX.Dobavljaci.Add(Novi);
                CTX.SaveChanges();
            }

            return JavaScript("window.location = '" + Url.Action("Index") + "'");
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Edituj_D(int id)
        {
            DobavljacVM Model = new DobavljacVM();
            Dobavljac Podaci = CTX.Dobavljaci.Where(x => x.Id == id).FirstOrDefault();

            Model.Lgradovi = CTX.Gradovi.ToList();

            Model.GradId = Podaci.GradId;
            Model.IdDobavljaca = Podaci.Id;
            Model.Naziv = Podaci.Naziv;

            return View("Edituj_D", Model);
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult SpasiIzmjenu_D(DobavljacVM Podaci)
        {
            if (!ModelState.IsValid)
            {
                Podaci.Lgradovi = CTX.Gradovi.ToList();
                return View("Edituj_D", Podaci);
            }

            Dobavljac Izmjenuti = CTX.Dobavljaci.Where(x => x.Id == Podaci.IdDobavljaca).FirstOrDefault();
            Izmjenuti.Naziv = Podaci.Naziv;
            Izmjenuti.GradId = Podaci.GradId;
            CTX.SaveChanges();

            return JavaScript("window.location = '" + Url.Action("Index") + "'");
        }
        [Pristup(Ovlasti = "Administrator")]
        public ActionResult Brisanje_D(int id)
        {
            try
            {
                CTX.Dobavljaci.Remove(CTX.Dobavljaci.Where(x => x.Id == id).FirstOrDefault());

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