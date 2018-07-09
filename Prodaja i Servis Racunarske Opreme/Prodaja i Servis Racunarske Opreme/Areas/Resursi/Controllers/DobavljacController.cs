using Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Models;
using Prodaja_i_Servis_Racunarske_Opreme.DAL;
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

        public ActionResult Dodaj_D()
        {
            DobavljacVM Model = new DobavljacVM();
            Model.Lgradovi = CTX.Gradovi.ToList();

            return View("Dodavanje_D", Model);
        }

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

            if (Pronadjeno == false)
            {
                Dobavljac Novi = new Dobavljac();
                Novi.Naziv = Nova_D.Naziv;
                Novi.GradId = Nova_D.GradId;
                CTX.Dobavljaci.Add(Novi);
                CTX.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edituj_D(int id)
        {
            DobavljacVM Model = new DobavljacVM();
            Dobavljac Podaci = CTX.Dobavljaci.Where(x => x.Id == id).FirstOrDefault();

            Model.GradId = Podaci.GradId;
            Model.IdDobavljaca = Podaci.Id;
            Model.Naziv = Podaci.Naziv;

            return View("Edituj_D", Model);
        }

        public ActionResult SpasiIzmjenu_D(DobavljacVM Podaci)
        {
            Dobavljac Izmjenuti = CTX.Dobavljaci.Where(x => x.Id == Podaci.IdDobavljaca).FirstOrDefault();
            Izmjenuti.Naziv = Podaci.Naziv;
            Izmjenuti.GradId = Podaci.GradId;
            CTX.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Brisanje_D(int id)
        {

            CTX.Dobavljaci.Remove(CTX.Dobavljaci.Where(x => x.Id == id).FirstOrDefault());

            CTX.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}