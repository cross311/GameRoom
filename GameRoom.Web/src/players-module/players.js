'use strict';

angular.module('gameroom.players', ['ui.router', 'gameroom.account', 'gameroom.config'])

.config(['$stateProvider', function ($stateProvider) {
  $stateProvider
    .state('login', {
      url: '/login',
      templateUrl: 'templates/players-module/login.html',
      controller: 'LoginCtrl as vm',
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
    .state('players', {
      abstract: true,
      template: '<div class="players-state" ui-view></div>',
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
          ],
        states: ['StatusSvc', function(statusSvc) {
          return statusSvc.getAvailableStates().then(function(response) {
              return response.data;
            },
            function(data) {
              return data;
            });
        }]
      }
  })
  .state('players.list', {
    url: '/players',
    templateUrl: 'templates/players-module/players-list.html',
    controller: 'PlayersListCtrl as vm'
  });
}])

.controller('LoginCtrl', ['players', 'AccountSvc', 'PlayersSvc', '$state', function(players, accountSvc, playerSvc, $state) {
  console.log('LoginCtrl Started');
  var vm = this;
  vm.players = players;
  vm.newPlayer = {name: '', email: ''};
  vm.authentication = accountSvc.authentication;

  function _isValidUserLoggedIn() {
    if (vm.authentication && vm.authentication.isAuth) {
      for (var index = 0; index < players.length; index++) {
        var p = players[index];
        if (vm.authentication.userId === p.id) {
          return true;
        }
      }
    }
    return false;
  }


    if (_isValidUserLoggedIn()) {
      $state.go('games');
      return;
    }

    accountSvc.logout();

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

.controller('PlayersListCtrl', ['players', 'states', 'StatusSvc', 'AccountSvc', function (players, states, statusSvc, accountSvc) {
  var vm = this;
    var player;
    vm.states = states;
    vm.players = players;
    vm.newStatus = {state: '', message: ''};

    var authentication = accountSvc.authentication;
    vm.currentPlayerId = authentication.userId;
    vm.canUpdate = authentication.isAuth;

    var currentPlayer;
    for (var index = 0; index < vm.players.length; index++) {
      player = vm.players[index];
      if (player.id === vm.currentPlayerId) {
        currentPlayer = player;
      }
    }

    vm.update = function(status) {
      status.player = currentPlayer.id;
      statusSvc.updatePlayerStatus(status).then(function() {
        currentPlayer.state = status.state;
        currentPlayer.message = status.message;
        vm.newStatus.state = '';
        vm.newStatus.message = '';
      });
    };

  statusSvc.getPlayerStatuses().then(
      function (response) {
        var statuses = response.data;
        for (var jIndex = 0; jIndex < vm.players.length; jIndex++) {
          player = vm.players[jIndex];

          for (var i = 0; i < statuses.length; i++) {
            var status = statuses[i];
            if (status.player === player.id) {
              player.state = status.state;
              player.message = status.message;
            }
          }
        }
      }, function (data) {
        console.error(data);
      }
  );
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
}])

.factory('StatusSvc', ['$http', 'config', function($http, config) {
  var statusSvc = {};

  function _getPlayerStatuses() {
    return $http.get(config.apiServer + '/playerstatuses').
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

  function _getAvailableStates() {

    return $http.get(config.apiServer + '/playerstates').
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

  function _updatePlayerStatus(status) {

    return $http.post(config.apiServer + '/playerstatuses', status).
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

  statusSvc.getPlayerStatuses = _getPlayerStatuses;
  statusSvc.getAvailableStates = _getAvailableStates;
  statusSvc.updatePlayerStatus = _updatePlayerStatus;

  return statusSvc;
}]);
