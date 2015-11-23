'use strict';

angular.module('notification.admin.controller', []).controller('AdminController', ['$scope', 'adminServices', '$state', '$cookieStore', '$window', function ($scope, adminServices, $state, $cookieStore, $window) {

    adminServices.getNotificationType().then(function (pl) {
        $scope.NotificationTypes = pl.data;

    });
    

    adminServices.getActivityType().then(function (pl) {
        $scope.ActivityTypes = pl.data;

    });

    
    adminServices.getUsers().then(function (pl) {
        $scope.Users = pl.data;

    });

    $scope.NotificationType=1;
    $scope.UserActivityType=1;
    $scope.SenderId=1;
    $scope.RecieverId = 1;
    $scope.saveNotification = function () {
        var notificationParam = {           
            NotificationType: $scope.NotificationType,
            UserActivityType: $scope.UserActivityType,
            SenderId: $scope.SenderId,
            RecieverId: $scope.RecieverId            
        };
        adminServices.saveNotification(notificationParam).then(function (pl) {
            $cookieStore.put('userId', $scope.RecieverId);

            $window.location.href = '/';

        });

       
    };

}]);