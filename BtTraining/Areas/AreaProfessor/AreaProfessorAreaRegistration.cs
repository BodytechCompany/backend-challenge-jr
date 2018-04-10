using System.Web.Mvc;

namespace BtTraining.Areas.AreaProfessor
{
    public class AreaProfessorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AreaProfessor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreaProfessor_default",
                "AreaProfessor/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}