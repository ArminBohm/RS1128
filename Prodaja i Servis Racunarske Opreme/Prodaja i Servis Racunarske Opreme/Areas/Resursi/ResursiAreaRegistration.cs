using System.Web.Mvc;

namespace Prodaja_i_Servis_Racunarske_Opreme.Areas.Resursi
{
    public class ResursiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Resursi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Resursi_default",
                "Resursi/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}