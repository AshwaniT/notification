using AttributeRouting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AttributeRouting.Web.Http;


namespace Notification.app_controller
{
    [RoutePrefix("api/notification")]
    public class NotificationController : ApiController
    {
        private readonly Repository.INotificationRepository _repository;


        public NotificationController(Repository.INotificationRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        [POST("")]
        public Notification.Models.Notification SaveNotification(Notification.Models.Notification notification)
        {
            return _repository.SaveNotification(notification);
        }

        [HttpPost]
        [POST("log/?userId={userId}")]
        public void SaveNotificationLog(long userId)
        {
            _repository.SaveNotificationLog(userId);
        }

        [GET("count/?userId={userId}")]
        public int GetNotificationcount(long userId)
        {
            return _repository.GetNewNotificationCount(userId);
        }

        [HttpGet]
        [GET("type/useractivity")]
        public IEnumerable<Notification.Models.UserActivityType> GetUserActivityType()
        {
            return _repository.GetUserActivityType();
        }

        [HttpGet]
        [GET("users")]
        public IEnumerable<Notification.Models.User> GetUsers()
        {
            return _repository.GetUser();
        }

        [HttpGet]
        [GET("user/id/?userId={userId}")]
        public Notification.Models.User GetUser(long userId)
        {
            return _repository.GetUser().First(x => x.Id == userId);
        }



        [HttpGet]
        [GET("")]
        //[Route("api/notification/all")]
        public IEnumerable<Notification.Models.NotificationViewModel> GetNotification(long userId)
        {
            return _repository.GetNotification(userId);
        }

        [HttpGet]
        [GET("type/notifications")]
        public IEnumerable<Notification.Models.NotificationType> GetNotificationType()
        {
            return _repository.GetNotificationType();
        }

    }
}