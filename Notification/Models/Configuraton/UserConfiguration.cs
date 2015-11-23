using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Notification.Models
{
    public class UserConfiguration: EntityTypeConfiguration<User>
    {
       public UserConfiguration()
        {
            ToTable("tblUser");
            HasKey(p => p.Id);
        }
    }
}