'use strict';

describe('example module', function() {

  beforeEach(module('gameroom.games'));

  describe('example controller', function(){
    it('should exist', inject(function($controller) {
      var view1Ctrl = $controller('GamesCtrl');
      expect(view1Ctrl).toBeDefined();
    }));
  });
});
