'use strict';

// Declare app level module which depends on views, and components
angular.module('supportPortal', [
  'ngRoute',
  'supportPortal.example'
]).
config(['$routeProvider', function($routeProvider) {
  $routeProvider.otherwise({redirectTo: '/example'});
}]);
