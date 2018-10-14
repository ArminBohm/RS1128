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

    public class HomeController : Controller
    {
        MyContext CTX = new MyContext();
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index(string UN = "", string Pass="", string Msg="")
        {
            ViewBag.UName = UN;
            ViewBag.Pass = Pass;
            ViewBag.Message = Msg;
            
            return View("LoginForma");
        }
        [AllowAnonymous]
        public ActionResult chkLogin(string UserName, string password)
        {
            Osoba Loged = new Osoba();
            Loged = CTX.Osobe.Where(x => x.UserName == UserName && x.Password == password).FirstOrDefault();


            if(Loged == null)
            {
                return RedirectToAction("Index", new { UN = UserName, Pass = "", Msg = " Ovaj korisnik ne postoji ili ste unjeli pogresnu lozinku " });
            }

            LogiraniSes LS = new LogiraniSes();
            Session["Logirani"] = null;

            LS.LogiraniId = Loged.Id;
            LS.Ime_Prezime = Loged.Ime + " " + Loged.Prezime;
            LS.UserName = Loged.UserName;
          
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
                    return RedirectToAction("Index", new { UN = UserName, Pass = "", Msg = " Vas korisnik jos nije aktivan " });
                }

            }
            FormsAuthentication.SetAuthCookie(LS.UserName, false);
            Session["Logirani"] = LS;
            return RedirectToAction("HomePage");
        }

        [Authorize]
        public ActionResult LogOff()
        {
            Session["Logirani"] = null;

            FormsAuthentication.SignOut();


            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult HomePage()
        {
            LogiraniSes ls = Session["Logirani"] as LogiraniSes;
            if (ls.Korisnik)
                return View("KorisnickiDio");
            return View("Index");
        }
    }
}