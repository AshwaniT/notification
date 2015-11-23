using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Notification.IOC
{
    public class StructureMapDependencyResolver: IDependencyResolver
    {
        public void Dispose()
        {

        }

        public object GetService(Type serviceType)
        {
            try
            {
                return serviceType.IsAbstract || serviceType.IsInterface ?
                    ObjectFactory.GetInstance(serviceType) : ObjectFactory.GetInstance(serviceType);
            }
            catch 
            {

                return null;
            }
        }


        public IDependencyScope BeginScope()
        {
            return this;
        }


        public IEnumerable<object> GetServices(Type serviceType)
        {
            return ObjectFactory.GetAllInstances(serviceType).Cast<object>();
        }
    }

}