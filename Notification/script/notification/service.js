'use strict';
angular.module('notificationDemo.services', []).factory('notificationservice', function ($http) {

    return {

        getNotification: function (userId) {
            return $http.get("/api/notification/?userId=" + userId);
          //var  notification= [{
          //      "Id": "1",
          //      "NotificationType": {"Id":"1","Name":"Wish list"},
          //      "UserActivityType": { "Id": "1", "Name": "Post" },
          //      "CreateDate": "5/2/2017",
          //      "Sender": { "Id": "3", "Name": "Amit" },
          //      "Reciever": { "Id": "1", "Name": "Ashwani" }
          //  },
          //  {
          //      "Id": "2",
          //      "NotificationType": { "Id": "1", "Name": "Wish list" },
          //      "UserActivityType": { "Id": "1", "Name": "Post" },
          //      "CreateDate": "5/2/2017",
          //      "Sender": { "Id": "2", "Name": "Ganesh" },
          //      "Reciever": { "Id": "5", "Name": "Amrita" }
          //  },
          //  {
          //      "Id": "1",
          //      "NotificationType": { "Id": "1", "Name": "Wish list" },
          //      "UserActivityType": { "Id": "1", "Name": "Post" },
          //      "CreateDate": "5/2/2017",
          //      "Sender": { "Id": "4", "Name": "Amol" },
          //      "Reciever": { "Id": "1", "Name": "Ganesh" }
          //  },
          //  {
          //      "Id": "1",
          //      "NotificationType": { "Id": "1", "Name": "Wish list" },
          //      "UserActivityType": { "Id": "3", "Name": "Edited" },
          //      "CreateDate": "5/2/2017",
          //      "Sender": { "Id": "6", "Name": "Amrita" },
          //      "Reciever": { "Id": "1", "Name": "Ashwani" }
          //  }, {
          //      "Id": "1",
          //      "NotificationType": { "Id": "1", "Name": "Wish list" },
          //      "UserActivityType": { "Id": "2", "Name": "Deleted" },
          //      "CreateDate": "5/2/2017",
          //      "Sender": { "Id": "3", "Name": "Amit" },
          //      "Reciever": { "Id": "4", "Name": "Amole" }
          //  }];
          //  return notification;
        },
        GetCount: function (userId) {
            return $http.get("/api/notification/count/?userId=" + userId);
        },
        
        getUserById: function (id) {
            return $http.get("/api/notification/user/id/?userId=" + id);
        },
        
        updateLog: function (userId) {
            var request = $http({
                method: "post",
                url: "/api/notification/log/?userId=" + userId
            });
            return request;
        },
        getUsers: function () {
            return $http.get("/api/notification/users");
        },

    }
});