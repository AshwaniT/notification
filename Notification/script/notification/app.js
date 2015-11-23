
'use strict';
angular.module('notificationDemo', ['notificationDemo.controller', 'notificationDemo.services', 'ui.router','ngCookies']);
angular.module('notificationDemo').config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider.state('notificationCount', {
        url: 'notificationCount',
        controller: 'NotificationCountController',
        templateUrl: 'partial/view/notification-count.html'
    })
});

angular.module('notificationDemo').run(['$state', function ($state) { $state.go('notificationCount'); }]);