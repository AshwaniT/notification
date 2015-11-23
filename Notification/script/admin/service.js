
'use strict';
angular.module('notification.admin.services', []).factory('adminServices', function ($http) {

    return {
        getUsers: function () {
            return $http.get("/api/notification/users");
        },
        getNotificationType: function () {
            return $http.get("/api/notification/type/notifications");
        },
        getActivityType: function () {
            return $http.get("/api/notification/type/useractivity");
        },
        saveNotification: function (notification) {
            var request = $http({
                method: "post",
                url: "/api/notification/",
                data: notification
            });
            return request;
        },
    }
});