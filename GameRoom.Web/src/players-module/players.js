'use strict';

angular.module('gameroom.players', ['ui.router', 'gameroom.account'])

.config(['$stateProvider', function ($stateProvider) {
    $stateProvider.state('players', {
        abstract: true,
        templateUrl: 'templates/players-module/players.html',
        controller: 'PlayersCtrl as vm',
        resolve: {
            players: ['PlayersSvc', function(playersSvc) {
                return playersSvc.getPlayers().then(
                    function (response) {
                        return response.data;
                    }, function (data) {
                        console.error(data);
                        return [];
                    }
                );
            }]
        }
    })
    .state('players.login', {
        url: '/login',
        views: {
            '@': {
                templateUrl: 'templates/players-module/login.html',
                controller: 'LoginCtrl as vm'
            }
        }

    });
}])

.controller('LoginCtrl', ['players', 'AccountSvc', function (players, accountSvc) {
    console.log('LoginCtrl Started');
    var vm = this;
    vm.players = players;

    vm.authentication = accountSvc.authentication;

    vm.login = function(player) {
        accountSvc.login(player);
    };
}])
.factory('PlayersSvc', ['$http', function($http) {
    var playersSvc = {};

    function _getPlayers() {
        return $http.get('http://localhost:49269/players').
        success(function (data) {
            // this callback will be called asynchronously
            // when the response is available
            return data;
        }).
        error(function (data) {
            // called asynchronously if an error occurs
            // or server returns response with an error status.
            return data;
        });
    }

    playersSvc.getPlayers = _getPlayers;

    return playersSvc;
}]);
