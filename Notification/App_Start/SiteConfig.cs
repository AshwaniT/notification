using System.Web.Mvc;

namespace Notification.App_Start
{
    public class SiteConfig
    {
        public static void BootStrap()
        {

            ControllerBuilder.Current.SetControllerFactory(new IOC.StructureMapControllerFactory());
        }
    }
}