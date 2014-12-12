var mainmodule = angular.module('main', ['ngResource', 'ngRoute', 'ui.bootstrap', 'ngTable']);

mainmodule.value('apiUrl', 'http://localhost:1456/');

mainmodule.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
            .when('/registration', { templateUrl: 'views/registration.html', controller: 'registrationCtrl' })
            .when('/customerlist', { templateUrl: 'views/customerlist.html', controller: 'customerlistCtrl' })
            .otherwise({ redirectTo: '/registration' });
}]);




    