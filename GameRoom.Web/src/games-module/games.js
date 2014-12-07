'use strict';

angular.module('gameroom.games', [
    'ui.router',
    'gameroom.account',
    'gameroom.players'
])

.config(['$stateProvider', function ($stateProvider) {
    $stateProvider.state('games', {
        url: '/games',
        templateUrl: 'templates/games-module/games-list.html',
        controller: 'GamesListCtrl as vm',
        resolve: {
            games: ['GamesSvc', function(gamesSvc) {
                 return gamesSvc.getGames().then(function (response) { return response.data; });
                }],
            gameTypes: ['GamesSvc', function(gamesSvc) {
                    return gamesSvc.getGameTypes().then(function(response) { return response.data; });
            }],
            players: ['PlayersSvc', function (playersSvc) {
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
    .state('games.new', {
        url: '/new',
        views: {
            '@': {
                templateUrl: 'templates/games-module/games-new.html',
                controller: 'GamesNewCtrl as vm'
            }
        }
    });
    }])

.controller('GamesListCtrl', ['gameTypes', 'games', 'players', function (gameTypes, games, players) {
    var vm = this;

    vm.gameTypes = gameTypes;
    vm.games = games;
    vm.players = players;

    vm.getPlayerName = function(playerId) {
        for (var index = 0; index < vm.players.length; index++) {
            var player = vm.players[index];
            if (player.id === playerId) {
                return player.name;
            }
        }
    };
}])

.controller('GamesNewCtrl', ['GamesSvc', '$state', 'gameTypes', 'games', 'players', function (gameSvc, $state, gameTypes, games, players) {
    var vm = this;
    vm.gameTypes = gameTypes;
    vm.games = games;
    vm.players = players;

    vm.newGameResult = {
        gameType: '',
        team1: {
            score: 0,
            players: []
        },
        team2: {
            score: 0,
            players: []
        }
    };

    vm.chooseGameType = function(gameType) {
        vm.newGameResult.gameType = gameType.name;
    };

    vm.choosePlayer = function(team, player) {
        team.players.push(player.id);
    };

    vm.removePlayer = function (team, player) {
        var index = team.players.indexOf(player.id);
        if (index > -1) {
            team.players.splice(index, 1);
        }
    };

    vm.saveAllowed = function() {
        var g = vm.newGameResult;
        var hasType = g.gameType !== '';
        var hasTeam1Players = g.team1.players.length > 0;
        var hasTeam2Players = g.team2.players.length > 0;

        var saveAllowed = hasType && hasTeam1Players && hasTeam2Players;
        return saveAllowed;
    };

    vm.record = function(gameResult) {
        gameSvc.record(gameResult).success(function (data) {
            vm.games.push(data);
            $state.go('games');
        });
    };
}])

.factory('GamesSvc', ['$http', function($http) {
    var gamesSvc = {};

    function _getGames() {
        return $http.get('http://localhost:49269/gameresults').
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

    function _getGameTypes() {
        return $http.get('http://localhost:49269/gametypes').
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

    function _record(gameResult) {
        return $http.post('http://localhost:49269/gameresults', gameResult).
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

    gamesSvc.getGames = _getGames;
    gamesSvc.getGameTypes = _getGameTypes;
    gamesSvc.record = _record;

    return gamesSvc;
}]);
