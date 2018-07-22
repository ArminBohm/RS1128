using Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi.Models;
using Prodaja_i_Servis_Racunarske_Opreme.DAL;
using Prodaja_i_Servis_Racunarske_Opreme.Helper;
using Prodaja_i_Servis_Racunarske_Opreme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Prodaja_i_Servis_Racunarske_Opreme.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        MyContext CTX = new MyContext();
        // GET: Home

        public ActionResult Index(string UN = "", string Pass="", string Msg="")
        {
            ViewBag.UName = UN;
            ViewBag.Pass = Pass;
            ViewBag.Message = Msg;
            
            return View("LoginForma");
        }
        public ActionResult chkLogin(string UserName, string password)
        {
            Osoba Loged = new Osoba();
            Loged = CTX.Osobe.Where(x => x.UserName == UserName && x.Password == password).FirstOrDefault();
            LogiraniSes LS = new LogiraniSes();
            Session["Logirani"] = null;


            LS.LogiraniId = Loged.Id;
            LS.Ime_Prezime = Loged.Ime + " " + Loged.Prezime;
            LS.UserName = Loged.UserName;
          

            if(Loged == null)
            {
                return RedirectToAction("Index", new { UN = UserName, Pass = "", Msg = " Ovaj user ne postoji ili ste unjeli pogresan password " });
            }
            
            if (CTX.Zaposlenici.Find(Loged.Id)!=null)
            {
                LS.Korisnik = false;
                LS.ZaduzenjeZaposlenika = CTX.Zaposlenici.Find(Loged.Id).Zaduzenje.Naziv;
            }
            else
            {
                LS.Korisnik = true;
                LS.StatusKorisnika= CTX.Korisnici.Where(x => x.Id == Loged.Id).FirstOrDefault().Status;

                if(LS.StatusKorisnika == false)
                {
                    return RedirectToAction("Index", new { UN = UserName, Pass = "", Msg = " Vas User jos nije aktivan " });
                }

            }
            FormsAuthentication.SetAuthCookie(LS.UserName, false);
            Session["Logirani"] = LS;
            if (LS.Korisnik == true)
            {
                return View("KorisnickiDio");
            }
            else
            {
                return View("Index");
            }
        }

        [Authorize]
        public ActionResult LogOff()
        {
            Session["Logirani"] = null;

            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }

    }
}