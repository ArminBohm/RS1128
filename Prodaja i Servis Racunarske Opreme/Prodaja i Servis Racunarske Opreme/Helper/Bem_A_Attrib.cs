using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodaja_i_Servis_Racunarske_Opreme.Helper
{
    public class PristupAttribute : AuthorizeAttribute
    {
        private string Redirekcija = "/Common/ErrMsg";
        public string Ovlasti { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            LogiraniSes LS = httpContext.Session["Logirani"] as LogiraniSes;
            bool Autorizovan = base.AuthorizeCore(httpContext);
            if (!Autorizovan || LS == null)
            {
                Redirekcija = "/Home/Index";
                return false;
            }
            if (Ovlasti.Contains(LS.ZaduzenjeZaposlenika.Trim()))
                return true;

            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult(Redirekcija);
        }
    }
}