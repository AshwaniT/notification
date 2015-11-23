using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notification.Models
{
    public class NotificationViewModel
    {
        public long Id { get; set; }
        public NotificationTypeViewModel NotificationType { get; set; }
        public UserActivityTypeViewModel UserActivityType { get; set; }
        public DateTime CreateDate { get; set; }
        public UserViewModel Sender { get; set; }
        public UserViewModel Reciever { get; set; }
        public string FormatedDate { get {
            return CreateDate.ToShortDateString();
        } }

    }
}