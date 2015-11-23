using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace Notification.Repository
{
    public class EFBase: DbContext 
    {
        public EFBase():this("")
        {

        }
        public EFBase(string connectionString):base(connectionString)
        { }

        protected ObjectContext ObjectContext
        {
            get
            {
                return ((IObjectContextAdapter)this).ObjectContext;
            }
        }
    }
}