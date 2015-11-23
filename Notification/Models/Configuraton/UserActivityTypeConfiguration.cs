using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Notification.Models
{
    public class UserActivityTypeConfiguration : EntityTypeConfiguration<UserActivityType>
    {
        public UserActivityTypeConfiguration()
        {
            ToTable("tblUserActivityType");
            HasKey(p => p.Id);
        }
    }
}