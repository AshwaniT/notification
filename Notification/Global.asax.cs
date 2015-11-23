using Notification.App_Start;
using StructureMap;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Notification
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ObjectFactory.Initialize(
                x => { x.AddRegistry<IOC.Container1>(); });
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            SiteConfig.BootStrap();
        }
    }
}