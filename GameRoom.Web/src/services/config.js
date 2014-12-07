'use strict';

angular.module('gameroom.config', []).
constant('environmentConfig', window.environmentConfig).
factory('config', ['environmentConfig', function (config) {
    // Add additional config stuff here.

    return config;
}]);
