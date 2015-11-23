using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Notification.Repository
{
    public class NotificationRepository : EFBase, INotificationRepository
    {
        public DbSet<Notification.Models.Notification> Notification { get; set; }
        public DbSet<Notification.Models.User> User { get; set; }
        public DbSet<Notification.Models.NotificationViewsLog> NotificationLog { get; set; }
        public DbSet<Notification.Models.NotificationType> NotificationType { get; set; }
        public DbSet<Notification.Models.UserActivityType> UserActivity { get; set; }
        public NotificationRepository()
            : base(ConfigurationManager.ConnectionStrings["notification"].ToString())
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<NotificationRepository>(null);
            modelBuilder.Configurations.Add(new Notification.Models.Configuraton.NotificationConfiguration());
            modelBuilder.Configurations.Add(new Notification.Models.UserConfiguration());
            modelBuilder.Configurations.Add(new Notification.Models.NotificationViewsLogConfiguration());
            modelBuilder.Configurations.Add(new Notification.Models.NotificationTypeConfiguration());
            modelBuilder.Configurations.Add(new Notification.Models.UserActivityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public Notification.Models.Notification SaveNotification(Notification.Models.Notification notification)
        {
            notification.CreateDate = DateTime.Now;
            if(notification.Id>0)
            {
                Entry(notification).State =  EntityState.Modified;
            }
            else
            {
                Notification.Add(notification);
            }
           
            SaveChanges();
            return notification;
        }

        public void SaveNotificationLog(long UserId)
        {
            var notificationLog = new Notification.Models.NotificationViewsLog()
            {
                LastViewedDate = DateTime.Now,
                UserId = UserId
            };
            if (NotificationLog.Any(x => x.UserId == UserId))
            {
                var existingLog = NotificationLog.First(x => x.UserId == UserId);
                existingLog.LastViewedDate = DateTime.Now;
               // notificationLog.Id = existingLog.Id;
                Entry(existingLog).State = EntityState.Modified;
                SaveChanges();
            }
            else
            {
                NotificationLog.Add(notificationLog);
                SaveChanges();
            }
        }

        public int GetNewNotificationCount(long UserId)
        {
            var lastViewedDate = DateTime.MinValue;
            if (NotificationLog.Any(x => x.UserId == UserId))
            {
                lastViewedDate = NotificationLog.Where(x => x.UserId == UserId).First().LastViewedDate;
            }

            if (!Notification.Any(x => x.RecieverId == UserId))
            {
                return 0;
            }
            return Notification.Count(x => x.RecieverId == UserId && x.CreateDate >= lastViewedDate);

        }

        public IEnumerable<Notification.Models.NotificationViewModel> GetNotification(long userId)
        {
            var lastViewedDate = DateTime.MinValue;
            if (NotificationLog.Any(x => x.UserId == userId))
            {
                lastViewedDate = NotificationLog.Where(x => x.UserId == userId).First().LastViewedDate;
            }
            if (!Notification.Any(x => x.RecieverId == userId))
            {
                return null;
            }
            var notification = from nt in Notification
                               join us in User on nt.RecieverId equals us.Id
                               join nty in NotificationType on nt.NotificationType equals nty.Id
                               join usa in UserActivity on nt.UserActivityType equals usa.Id
                               join uss in User on nt.SenderId equals uss.Id
                               where nt.RecieverId==userId
                              // from snd in us
                              // let senders =User.FirstOrDefault(x=>x.Id==nt.SenderId)
                               select new Notification.Models.NotificationViewModel()
                               {
                                   Id = nt.Id,
                                   CreateDate = nt.CreateDate,
                                   NotificationType = new Models.NotificationTypeViewModel
                                   {
                                       Id = nty.Id,
                                       Name = nty.Name
                                   },
                                   Reciever = new Models.UserViewModel
                                   {
                                       Id = us.Id,
                                       Name = us.Name
                                   },
                                   Sender =  new Models.UserViewModel
                                   {
                                       Id = uss.Id,
                                       Name = uss.Name
                                   },
                                   UserActivityType = new Models.UserActivityTypeViewModel
                                   {
                                       Id = usa.Id,
                                       Name = usa.Name
                                   }
                               };

            return notification.ToList();
        }
        public IEnumerable<Notification.Models.User> GetUser()
        {
            return User.ToList();
        }
        public IEnumerable<Notification.Models.NotificationType> GetNotificationType()
        {
            return NotificationType.ToList();
        }
        public IEnumerable<Notification.Models.UserActivityType> GetUserActivityType()
        {
            return UserActivity.ToList();
        }
    }
}