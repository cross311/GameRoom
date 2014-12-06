'use strict';

angular.module('supportPortal.example', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/example', {
    templateUrl: 'templates/example-module/example.html',
    controllerAs: 'ExampleCtrl'
  });
}])

.controller('ExampleCtrl', [function() {
  console.log('ExampleCtrl Started');
}]);
