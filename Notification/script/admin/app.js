angular.module('notification.admin', ['notification.admin.controller', 'notification.admin.services', 'ui.router', 'ngCookies']);
angular.module('notification.admin').config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider.state('insertnotification', {
        url: 'insertnotification',
        controller: 'AdminController',
        templateUrl: '/partial/view/admin/notification.html'
    })
});

angular.module('notification.admin').run(['$state', function ($state) { $state.go('insertnotification'); }]);