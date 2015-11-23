using Notification.Repository;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notification.IOC
{
    public class Container1:Registry 
    {
        public Container1()
        {
            For<INotificationRepository>().Use<NotificationRepository>();
        }
    }
}