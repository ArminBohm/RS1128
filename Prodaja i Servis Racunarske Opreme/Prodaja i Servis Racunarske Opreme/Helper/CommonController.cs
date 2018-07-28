using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace RS1_110.Helper
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
    }
}