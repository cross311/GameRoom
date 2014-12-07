'use strict';

angular.module('gameroom.games', ['ui.router', 'gameroom.account'])

.config(['$stateProvider', function ($stateProvider) {
    $stateProvider.state('games', {
                url: '/games',
                templateUrl: 'templates/games-module/games-list.html',
                controller: 'GamesListCtrl as vm'
            });
    }])

.controller('GamesListCtrl', ['AccountSvc', 'GamesSvc', function (accountSvc, gameSvc) {
    var vm = this;

    vm.gameTypes = [];
    vm.games = [];
    gameSvc.getGameTypes().success(function (gameTypes) {
        vm.gameTypes = gameTypes;
    });
    gameSvc.getGames().success(function(games) {
        vm.games = games;
    });
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
