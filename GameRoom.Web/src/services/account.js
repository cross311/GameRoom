'use strict';

angular.module('gameroom.account', ['LocalStorageModule', 'ui.router'])
.config([
    'localStorageServiceProvider', function (localStorageServiceProvider) {
        localStorageServiceProvider.setPrefix('gameroom');
    }
])
.controller('AccountCtrl', ['AccountSvc', '$state', function (accountSvc, $state) {
    var vm = this;

    vm.authentication = accountSvc.authentication;

    vm.logout = function() {
        accountSvc.logout();
        $state.go('players.login');
    };
}])
.factory('AccountSvc', [
    'localStorageService', function (localStorageService) {
        var accountSvc = {};
        var storageKey = 'authorizationData';

        var _authentication = {
            isAuth: false,
            name: 'Not Logged In',
            userId: 0
        };

        function _login(user) {
            if (!user) {
                return;
            }


            localStorageService.set(storageKey, {
                name: user.name,
                userId: user.id
            });

            _authentication.isAuth = true;
            _authentication.name = user.name;
            _authentication.userId = user.id;

        }

        function _logout() {
            localStorageService.remove(storageKey);

            _authentication.isAuth = false;
            _authentication.name = 'Not Logged In';
            _authentication.userId = 0;

        }

        function _fillAuthData() {
            var authData = localStorageService.get(storageKey);

            if (authData) {
                _authentication.isAuth = true;
                _authentication.name = authData.name;
                _authentication.userId = authData.uAserId;
            }
        }

        accountSvc.authentication = _authentication;
        accountSvc.login = _login;
        accountSvc.logout = _logout;
        accountSvc.fillAuthData = _fillAuthData;

        return accountSvc;
    }
]);
