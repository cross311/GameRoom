'use strict';

angular.module('gameroom.players', ['ui.router', 'gameroom.account', 'gameroom.config'])

.config(['$stateProvider', function ($stateProvider) {
        $stateProvider.state('players', {
                abstract: true,
                template: '',
                controller: function (){},
                resolve: {
                    players: [
                        'PlayersSvc', function(playersSvc) {
                            return playersSvc.getPlayers().then(
                                function(response) {
                                    return response.data;
                                }, function(data) {
                                    console.error(data);
                                    return [];
                                }
                            );
                        }
                    ]
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

.controller('LoginCtrl', ['players', 'AccountSvc', 'PlayersSvc', '$state', function (players, accountSvc, playerSvc, $state) {
    console.log('LoginCtrl Started');
    var vm = this;
    vm.players = players;
    vm.newPlayer = {name: '', email: ''};

    vm.authentication = accountSvc.authentication;

    if (vm.authentication && vm.authentication.isAuth) {
        $state.go('games');
    }

    vm.login = function(player) {
        accountSvc.login(player);
        $state.go('games');
    };

    vm.register = function(newPlayer) {
        playerSvc.register(newPlayer).then(function (response) {
            vm.newPlayer.name = '';
            vm.newPlayer.email = '';
            var player = response.data;
            vm.players.push(player);
            vm.login(player);
        }, function(data) {
            console.error(data);
        });
    };
}])

.factory('PlayersSvc', ['$http', 'config', function ($http, config) {
    var playersSvc = {};

    function _getPlayers() {
        return $http.get(config.apiServer + '/players').
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

    function _register(player) {
        return $http.post(config.apiServer + '/players', player).
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
    playersSvc.register = _register;

    return playersSvc;
}]);
