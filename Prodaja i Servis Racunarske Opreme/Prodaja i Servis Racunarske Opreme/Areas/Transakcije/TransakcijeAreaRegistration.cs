using System.Web.Mvc;

namespace Prodaja_i_Servis_Racunarske_Opreme.Areas.Transakcije
{
    public class TransakcijeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Transakcije";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Transakcije_default",
                "Transakcije/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}