//(function () {

    var app = angular.module('withSignalR', ['SignalR','notificationDemo.services', 'ui.router', 'ngCookies']);
    app.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
        $stateProvider.state('notificationCount', {
            url: 'notificationCount',
            controller: 'NotificationCountController',
            templateUrl: '/partial/view/notification-count.html'
        })
    });

    app.run(['$state', function ($state) { $state.go('notificationCount'); }]);

app.controller('NotificationCountController', ['Hub', '$scope', 'notificationservice', '$state', '$interval', '$rootScope', '$cookieStore',
    function (Hub, $scope, notificationservice, $state, $interval, $rootScope, $cookieStore) {
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

       
        //Hub setup
        var hub = new Hub('notification', {
            listeners: {
                'refreshNotification': function (value) {
                    console.log(value + ' ' + value.userId + ' ' + value.notificationCount);
                    if ($scope.userId == value.userId) {
                        $scope.notificationCount = value.notificationCount;
                        $rootScope.$apply();
                    }
                }
            },
            methods: ['newnotification'],
            errorHandler: function (error) {
                console.error(error);
            }
        });



        $scope.updateLog = function () {
           
            if ($scope.hasClicked) {
                $scope.hasClicked = false;
            }
            else {
                $scope.hasClicked = true;
                var promisePost = notificationservice.updateLog($scope.userId);
                promisePost.then(function (pl) {
                    //   $scope.notificationCount = 0;
                    hub.newnotification($scope.userId);
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

            $window.location.href = '/home/notification';

        };
    }]);



//   // $.connection.hub.start();
//});