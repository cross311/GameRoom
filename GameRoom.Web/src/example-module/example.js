'use strict';

angular.module('gameroom.example', ['ui.router'])

.config(['$stateProvider', function ($stateProvider) {
    $stateProvider.state('example', {
        url: '/example',
        templateUrl: 'templates/example-module/example.html',
        controller: 'ExampleCtrl as vm'
    });
}])

.controller('ExampleCtrl', [function() {
  console.log('ExampleCtrl Started');
}]);
