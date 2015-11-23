using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Notification.Models.Custom;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace Notification.Models.Custom
{
    
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var idProvider = new CustomUserIdProvider();

            //GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);

            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}