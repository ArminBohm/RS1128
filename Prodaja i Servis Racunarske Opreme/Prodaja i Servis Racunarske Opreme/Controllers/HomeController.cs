using Prodaja_i_Servis_Racunarske_Opreme.DAL;
using Prodaja_i_Servis_Racunarske_Opreme.Helper;
using Prodaja_i_Servis_Racunarske_Opreme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodaja_i_Servis_Racunarske_Opreme.Controllers
{
    public class HomeController : Controller
    {
        MyContext CTX = new MyContext();
        // GET: Home

        public ActionResult Index(string UN = "", string Pass="", string Msg="")
        {
            ViewBag.UName = UN;
            ViewBag.Pass = Pass;
            ViewBag.Message = Msg;

            //List<Racun> Racuni = CTX.Racuni.ToList();
            return View("LoginForma");
        }

        public ActionResult chkLogin(string UserName, string password)
        {
            Osoba Loged = new Osoba();
            Loged = CTX.Osobe.Where(x => x.UserName == UserName && x.Password == password).FirstOrDefault();
          

            if(Loged == null)
            {
                return RedirectToAction("Index", new { UN = UserName, Pass = "", Msg = " Ovaj user ne postoji ili ste unjeli pogresan password " });
            }
            MyGlobal.Loged_Z = null;
            MyGlobal.Loged_K = null;

            if (CTX.Zaposlenici.Find(Loged.Id)!=null)
            {
                MyGlobal.Loged_Z = CTX.Zaposlenici.Where(x => x.Id == Loged.Id).FirstOrDefault();           
            }
            else
            {
                MyGlobal.Loged_K = CTX.Korisnici.Where(x => x.Id == Loged.Id).FirstOrDefault();
                if(MyGlobal.Loged_K.Status == false)
                {
                    return RedirectToAction("Index", new { UN = UserName, Pass = "", Msg = " Vas User jos nije aktivan " });
                }
            }


            return View("Index");
        }

    }
}