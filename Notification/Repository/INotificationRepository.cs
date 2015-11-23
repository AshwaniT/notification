using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Repository
{
    public interface INotificationRepository
    {
        Notification.Models.Notification SaveNotification(Notification.Models.Notification notification);
        void SaveNotificationLog(long UserId);
        int GetNewNotificationCount(long UserId);
        IEnumerable<Notification.Models.NotificationViewModel> GetNotification(long userId);
        IEnumerable<Notification.Models.User> GetUser();
        IEnumerable<Notification.Models.NotificationType> GetNotificationType();
        IEnumerable<Notification.Models.UserActivityType> GetUserActivityType();
    }
}
