using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Notification.Models.Configuraton
{
    public class NotificationConfiguration:EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            ToTable("tblNotification");
            HasKey(p => p.Id);
        }
    }
}