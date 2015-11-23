using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notification.Models
{
    public class Notification
    {
        public long Id { get; set; }
        public byte NotificationType { get; set; }
        public byte UserActivityType { get; set; }
        public DateTime CreateDate { get; set; }
        public long SenderId { get; set; }
        public long RecieverId { get; set; }

    }
}