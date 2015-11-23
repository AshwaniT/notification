'use strict';

angular.module('notificationDemo.controller', []).controller('NotificationCountController', ['$scope', 'notificationservice', '$state', '$interval', '$rootScope', '$cookieStore', function ($scope, notificationservice, $state, $interval, $rootScope, $cookieStore) {
    $scope.userId = parseInt($cookieStore.get('userId'));
    $scope.shouldUpdate = true;
    $scope.hasClicked = false;;
    $scope.hasNoValue = false;
    $scope.hasValue = false;
    if (!$scope.userId) {
        $scope.userId = 1;
    }

    notificationservice.getUserById($scope.userId).then(function (pl) {
        $scope.UserName = pl.data.Name;

    },
              function (errorPl) {

              });

    var promiseGet = notificationservice.GetCount($scope.userId);
    promiseGet.then(function (pl) {
        $scope.notificationCount = pl.data;

    },
              function (errorPl) {

              });

    $scope.getCount = function () {
        return notificationservice.GetCount($scope.userId);
    };
    this.loadNotifications = function () {
        notificationservice.GetCount($scope.userId).then(function (d) {
            $scope.notificationCount = d.data;
        });
    };

    $interval(function () {
        this.loadNotifications();
    }.bind(this), 10000);

    $scope.updateLog = function () {
        //console.log("nit");
        if ($scope.hasClicked) {
            $scope.hasClicked = false;
        }
        else {
            $scope.hasClicked = true;
            var promisePost = notificationservice.updateLog($scope.userId);
            promisePost.then(function (pl) {
                $scope.notificationCount = 0;

            }, function (err) {
                console.log("Err" + err);
            });

            var promiseGet = notificationservice.getNotification($scope.userId);
            promiseGet.then(function (pl) {
                $scope.notifications = pl.data;
                if ($scope.notifications && $scope.notifications.length > 0) {

                    $scope.hasNoValue = false;
                    $scope.hasValue = true;
                }
                else {

                    $scope.hasNoValue = true;
                    $scope.hasValue = false;
                }
            },
                      function (errorPl) {

                      });

        }

    };

    //window.onclick = function () {
    //    if ($scope.hasClicked) {
    //        $scope.hasClicked = false;

    //        // You should let angular know about the update that you have made, so that it can refresh the UI
    //        $scope.$apply();
    //    }
    //};

  

}]).controller('UserController', ['$scope', 'notificationservice', '$rootScope', '$state', '$window', '$cookieStore', function ($scope, notificationservice, $rootScope, $state, $window, $cookieStore) {

    notificationservice.getUsers().then(function (pl) {
        $scope.users = pl.data;
        console.log(pl.data[0].Name);

    });

    var selectedId = parseInt($cookieStore.get('userId'));
    if (!selectedId) {
        selectedId = 1;
    }

    $scope.userModel = { 'Id': selectedId };

    $scope.UserChange = function () {
        // $cookies.userId = $scope.userModel.Id;
        $cookieStore.put('userId', $scope.userModel.Id);

        $window.location.href = '/';

    };
}]);