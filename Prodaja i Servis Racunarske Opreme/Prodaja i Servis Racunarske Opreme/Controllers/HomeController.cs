using Prodaja_i_Servis_Racunarske_Opreme.DAL;
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

        public ActionResult Index()
        {

            List<Racun> Racuni = CTX.Racuni.ToList();
            return View();
        }
    }
}