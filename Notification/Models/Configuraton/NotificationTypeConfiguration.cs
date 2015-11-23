using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Notification.Models
{
    public class NotificationTypeConfiguration : EntityTypeConfiguration<NotificationType>
    {
        public NotificationTypeConfiguration()
        {
            ToTable("tblNotificationType");
            HasKey(p => p.Id);
        }
    }
}