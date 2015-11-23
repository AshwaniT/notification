using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notification.Models.Custom
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            var userId = request.Cookies["userId"];
            return userId.ToString();
        }
    }
}