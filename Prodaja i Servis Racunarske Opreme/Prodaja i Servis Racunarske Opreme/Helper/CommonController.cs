using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Prodaja_i_Servis_Racunarske_Opreme.Helper
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult ErrMsg()
        {
            ViewBag.IsAjaxRequest = 0;
            if (Request.IsAjaxRequest())
                ViewBag.IsAjaxRequest = 1;
            ViewData["Sadrzaj"] = "~/Views/Common/AutErrView.cshtml";
            return View("PopUpModal");
        }
        public ActionResult DelMsg()
        {
            ViewBag.IsAjaxRequest = 0;
            if (Request.IsAjaxRequest())
                ViewBag.IsAjaxRequest = 1;
            ViewData["Sadrzaj"] = "~/Views/Common/ErrDelView.cshtml";
            return View("PopUpModal");
            // return View("../../Views/Common/ErrDelView");
        }
    }
}