using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notification.Models.custom
{
    [HubName("notification")]
    public class NotificationHub:Hub
    {
        public void NewNotification(string userId)
        {
            var count = new Repository.NotificationRepository().GetNewNotificationCount(long.Parse(userId));
            Clients.All.refreshNotification(new { userId = userId, notificationCount = count });
        }
    }


}