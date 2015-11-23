using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notification.Models
{
    public class NotificationViewsLog
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime LastViewedDate { get; set;}
    }
}