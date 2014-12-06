'use strict';

// Declare app level module which depends on views, and components
angular.module('gameroom', [
  'ui.router',
  'gameroom.example'
]).
config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    //
    // For any unmatched url, redirect to /example
    $urlRouterProvider.otherwise('/example');
}]);
