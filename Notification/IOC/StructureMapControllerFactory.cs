using StructureMap;
using System.Web.Mvc;

namespace Notification.IOC
{///This class wil be used for initilizing MVC controller
    public class StructureMapControllerFactory: DefaultControllerFactory
    {
        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            var controllerType = base.GetControllerType(requestContext, controllerName);
            return controllerType == null ?
                base.CreateController(requestContext, controllerName) :
                ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}