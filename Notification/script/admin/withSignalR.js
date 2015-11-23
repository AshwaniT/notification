
var app = angular.module('withSignalRadmin', ['SignalR', 'notification.admin.services', 'ui.router', 'ngCookies']);



    app.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
        $stateProvider.state('insertnotification', {
            url: 'insertnotification',
            controller: 'AdminController',
            templateUrl: '/partial/view/admin/notification.html'
        })
    });
    app.run(['$state', function ($state) { $state.go('insertnotification'); }]);



  


    app.controller('AdminController', ['Hub','$rootScope','$scope', 'adminServices', '$state', '$cookieStore', '$window', function (Hub,$rootScope, $scope, adminServices, $state, $cookieStore, $window) {

        //Hub setup
        var hub = new Hub('notification', {
            //listeners: {
            //    'refreshNotification': function (value) {
            //        console.log(value + ' ' + value.userId + ' ' + value.notificationCount);
            //        if ($scope.userId == value.userId) {
            //            $scope.notificationCount = value.notificationCount;
            //            $rootScope.$apply();
            //        }
            //    }
            //},
            methods: ['newnotification'],
            errorHandler: function (error) {
                console.error(error);
            }
        });



        adminServices.getNotificationType().then(function (pl) {
            $scope.NotificationTypes = pl.data;

        });


        adminServices.getActivityType().then(function (pl) {
            $scope.ActivityTypes = pl.data;

        });


        adminServices.getUsers().then(function (pl) {
            $scope.Users = pl.data;

        });

        $scope.NotificationType = 1;
        $scope.UserActivityType = 1;
        $scope.SenderId = 1;
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
                hub.newnotification($scope.RecieverId);
                $window.location.href = '/home/notification';

            });


        };

    }]);


