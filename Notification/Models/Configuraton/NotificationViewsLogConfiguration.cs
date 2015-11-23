using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Notification.Models
{
    public class NotificationViewsLogConfiguration : EntityTypeConfiguration<NotificationViewsLog>
    {
        public NotificationViewsLogConfiguration()
        {
            ToTable("tblNotificationViewsLog");
            HasKey(p => p.Id);
        }
    }
}