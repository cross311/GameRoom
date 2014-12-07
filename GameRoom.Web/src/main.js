'use strict';

// Declare app level module which depends on views, and components
angular.module('gameroom', [
  'ui.router',
  'gameroom.players',
  'gameroom.account',
  'gameroom.games'
]).
config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    //
    // For any unmatched url, redirect to /login
    $urlRouterProvider.otherwise('/login');
}]).
run(['AccountSvc', function(accountSvc) {
    accountSvc.fillAuthData();
}]);
